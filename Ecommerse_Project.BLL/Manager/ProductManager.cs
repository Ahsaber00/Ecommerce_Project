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


        public async Task<ProductDetailsDto> AddAsync(CreateProductDto productDto)
        {
            var newProduct = _mapper.Map<Product>(productDto);

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



        public async Task<IEnumerable<GetAllProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync(p => p.Images, p => p.Category);
            var result= _mapper.Map<List<GetAllProductDto>>(products);
            return result;
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



        public async Task<ProductDetailsDto> UpdateAsync(UpdateProductDto productDto)
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

            var mainCategory = category.ParentCategory.Name;
            var subCategory = category.Name;

            // Update product details
            _mapper.Map(productDto, product);

            // Delete old images if provided
            if (productDto.Images != null)
            {
                if (product.Images.Any())
                {
                    var oldImages = product.Images.ToList();
                    foreach (var image in oldImages)
                    {
                        // Delete from server and database
                        _imageManagementService.DeleteImageAsync(image.Url);
                        await _unitOfWork.Images.DeleteAsync(image.Id);
                    }
                }

                // Add new images
                var imagePaths = await _imageManagementService.AddImageAsync(productDto.Images, mainCategory, subCategory, product.Id);
                foreach (var path in imagePaths)
                {
                    var image = new Image
                    {
                        Url = path,
                        ProductId = product.Id,
                    };
                    await _unitOfWork.Images.AddAsync(image);
                }
            }

            // Save updates
            _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.SaveAll();

            return _mapper.Map<ProductDetailsDto>(product);
        }
    }
}
