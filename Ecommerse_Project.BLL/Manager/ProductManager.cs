using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Services;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageManagementService _imageManagementService;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper, IImageManagementService imageManagementService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageManagementService = imageManagementService;
        }


        public async Task<ProductDetailsDto> AddAsync(string AdminId, CreateProductDto productDto)
        {
            var newProduct = _mapper.Map<Product>(productDto);
            newProduct.AdminId = AdminId;   

            // Add product to database
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.SaveAll();

            // Ensure category exists
            var category = await _unitOfWork.Categories.GetByIdAsync(newProduct.CategoryId, c => c.ParentCategory);
            if (category == null)
            {
                throw new Exception("Category does not exist");
            }

            //Extract the main and the subcategory names for the directory of the image
            var mainCategory = category.ParentCategory.Name;
            var subCategory = category.Name;


            // Save images in wwwroot and the paths in the database
            var imagePaths = await _imageManagementService.AddImageAsync(productDto.Images, mainCategory, subCategory, newProduct.Id);
            foreach (var imagePath in imagePaths)
            {
                var image = new Image
                {
                    Url = imagePath,
                    ProductId = newProduct.Id,
                };
                await _unitOfWork.Images.AddAsync(image);
            }

            // Commit changes
            await _unitOfWork.SaveAll();

            var products= await _unitOfWork.Products.GetAllAsync(p=>p.Category,p=>p.Images);
            var fullProduct =products.FirstOrDefault(p => p.Id == newProduct.Id);
            return _mapper.Map<ProductDetailsDto>(fullProduct);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id, p => p.Images);
            if (product == null)
            {
                return false;
            }

            // Delete associated images
            //if (product.Images != null && product.Images.Count>0)
            //{
            //    foreach (var image in product.Images)
            //    {
            //        _imageManagementService.DeleteImageAsync(image.Url);
            //        await _unitOfWork.Images.DeleteAsync(image.Id);
            //    }
            //}

            // Delete the product
            await _unitOfWork.Products.DeleteAsync(id);
            await _unitOfWork.SaveAll();
            return true;

        }
        
        public async Task<DashboardResultDto> GetAllProductsDashboardAsync(DashboardPaginationProductsDto pagination)
        {
            var products=await _unitOfWork.Products.GetAllAsync(p=>p.Category,p=>p.Admin,p=>p.Images);
            products = products.OrderBy(p => p.Name);
            int PageNumber=pagination.PageNumber;
            int PageSize=pagination.PageSize;

            //apply pagination
            var paginatedProducts = await products.Skip((PageNumber-1)*PageSize).Take(PageSize).ToListAsync();
            var result=_mapper.Map<List<DashboardProductDto>>(paginatedProducts);
            return new DashboardResultDto
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                Products = result

            };

        }

        public async Task<PaginatedProductResultDto> GetAllProductsAsync(ProductFilterDto? filter)
        {
            var query = await _unitOfWork.Products.GetAllAsync(p => p.Images, p => p.Category);

            // No filter is provided, return random products for the homepage
            if (filter == null)
            {
                // Randomize the products (using Guid.NewGuid() for a random sort)
                query = query.OrderBy(p => Guid.NewGuid());
                var totalCount = await query.CountAsync();
                var products = await query.Take(9).ToListAsync(); // Default page size for homepage
                var productDtos = _mapper.Map<List<GetAllProductDto>>(products);

                return new PaginatedProductResultDto
                {
                    TotalCount = totalCount,
                    PageNumber = 1,
                    PageSize = 9,
                    Products = productDtos
                };
            }

            //Filtering by main category (Men,Women)
            if(filter.CategoryId.HasValue)
            {
                query=query.Where(p=>p.Category.ParentCategoryId == filter.CategoryId);
            }

            // Filtering by Subcategory
            if (filter.SubcategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filter.SubcategoryId);
            }

            // Filtering by Target Audience (Men, Women)
            if (filter.TargetAudience.HasValue)
            {
                query = query.Where(p => p.TargetAudience == filter.TargetAudience.Value);
            }
            //else if (filter.CategoryId.HasValue)
            //{
            //    // Get products under any subcategory of the main category
            //    query = query.Where(p => p.Category.ParentCategoryId == filter.CategoryId);
            //}

            if (filter.Sizes != null && filter.Sizes.Any())
            {
                query = query.Where(p => filter.Sizes.Contains(p.Size));
            }

            if (filter.Colors != null && filter.Colors.Any())
            {
                query = query.Where(p => filter.Colors.Contains(p.Color));
            }

            if (filter.Brands != null && filter.Brands.Any())
            {
                query = query.Where(p => filter.Brands.Contains(p.Brand));
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= filter.MaxPrice.Value);
            }

            // Sorting
            switch (filter.SortBy?.ToLower())
            {
                case "price-asc":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "price-desc":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                case "name":
                    query = query.OrderBy(p => p.Name);
                    break;
                default:
                    query = query.OrderBy(p => p.Name); // Default sort by name for filtered results
                    break;
            }

            
            
            int PageSize = filter.PageSize.Value;
            int PageNumber = filter.PageNumber.Value;

            //total count of filtered products before pagination
            var totalCountFiltered = await query.CountAsync();

            //Apply pagination
            var filteredProducts=await query
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var result=_mapper.Map<List<GetAllProductDto>>(filteredProducts);
            return new PaginatedProductResultDto
            {
                TotalCount = totalCountFiltered,
                PageNumber = PageNumber,
                PageSize = PageSize,
                Products = result
            };

        }


        public async Task<ProductDetailsDto> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id, p => p.Category, p => p.Images);
            if (product == null)
            {
                return null;
            }

            var result= _mapper.Map<ProductDetailsDto>(product);
            return result;
        }



        public async Task<ProductDetailsDto> UpdateAsync(string AdminName, UpdateProductDto productDto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(productDto.Id);
            if (product == null)
            {
                throw new Exception("Product does not exist");
            }

            // Ensure category exists
            var category = await _unitOfWork.Categories.GetByIdAsync(productDto.SubCategoryId);
            if (category == null)
            {
                throw new Exception("Invalid Category");
            }
            var maincategory = await _unitOfWork.Categories.GetByIdAsync(productDto.MainCategoryId);
            if (maincategory == null)
            {
                throw new Exception("Invalid Category");
            }


            var mainCategory = maincategory.Name;
            var subCategory = category.Name;

            // Update product details
            _mapper.Map(productDto, product);

            // Delete old images if provided
            //if (productDto.Images != null)
            //{
            //    if (product.Images.Any())
            //    {
            //        var oldImages = product.Images.ToList();
            //        foreach (var image in oldImages)
            //        {
            //            // Delete from server and database
            //            _imageManagementService.DeleteImageAsync(image.Url);
            //            await _unitOfWork.Images.DeleteAsync(image.Id);
            //        }
            //    }

            //    // Add new images
            //    var imagePaths = await _imageManagementService.AddImageAsync(productDto.Images, mainCategory, subCategory, product.Id);
            //    foreach (var path in imagePaths)
            //    {
            //        var image = new Image
            //        {
            //            Url = path,
            //            ProductId = product.Id,
            //        };
            //        await _unitOfWork.Images.AddAsync(image);
            //    }
            //}

            // Save updates
            product.ModifiedAt = DateTime.UtcNow;
            product.ModifiedBy = AdminName;
            _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveAll();

            return _mapper.Map<ProductDetailsDto>(product);
        }
    }
}
