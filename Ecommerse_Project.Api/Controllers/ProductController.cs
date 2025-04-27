using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Services;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using Ecommerse_Project.DAL.Repositories.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce__Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageManagementService _imageManagementService;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IImageManagementService imageManagementService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageManagementService = imageManagementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _unitOfWork.Products.GetAllAsync(p => p.Images, p => p.Category);
                var result = _mapper.Map<List<GetAllProductDto>>(products);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(id, p => p.Category, p => p.Images);
                var result = _mapper.Map<ProductDetailsDto>(product);
                if (product == null)
                {
                    return NotFound("Product not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] CreateProductDto createProductDto)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(createProductDto);
                await _unitOfWork.Products.AddAsync(newProduct);
                await _unitOfWork.SaveAll();
                var category = await _unitOfWork.Categories.GetByIdAsync(newProduct.CategoryId, c => c.ParentCategory);
                if (category == null)
                {
                    return BadRequest("Category does not exist");
                }
                var mainCategory = category.ParentCategory.Name ?? category.Name;
                var subCategory = category.ParentCategory is not null ? category.Name : "General";

                //save the images and get their paths
                var imagePaths = await _imageManagementService.AddImageAsync(createProductDto.Images, mainCategory, subCategory, newProduct.Id);
                foreach (var imagePath in imagePaths)
                {
                    var image = new Image
                    {
                        Url = imagePath,
                        ProductId = newProduct.Id,
                    };
                    await _unitOfWork.Images.AddAsync(image);
                }
                await _unitOfWork.SaveAll();
                return CreatedAtAction("GetById", new { id = newProduct.Id }, newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromForm] UpdateProductDto updateProductDto)
        {
            try
            {
                if (id != updateProductDto.Id)
                {
                    return BadRequest("Id mismatch.");
                }
                var product = await _unitOfWork.Products.GetByIdAsync(id);
                if (product == null)
                {
                    return BadRequest("Product does not exist");
                }
                var category = await _unitOfWork.Categories.GetByIdAsync(updateProductDto.CategoryId);
                if (category == null)
                {
                    return BadRequest("Invalid Category");
                }
                var mainCategory = category.ParentCategory.Name ?? category.Name;
                var subCategory = category.ParentCategory.Name != null ? category.Name : "General";

                // Update product details
                _mapper.Map(updateProductDto, product);

                //delete old product photos
                if (updateProductDto.Images != null)
                {
                    if (product.Images.Any())
                    {
                        var oldImages = product.Images.ToList();
                        foreach (var image in oldImages)
                        {
                            //delete from server(wwwroot folder)
                            _imageManagementService.DeleteImageAsync(image.Url);

                            //delete path from database
                            await _unitOfWork.Images.DeleteAsync(image.Id);

                        }
                    }
                }

                //get the images and add them to wwwroot
                var imagePaths = await _imageManagementService.AddImageAsync(updateProductDto.Images, mainCategory, subCategory, product.Id);

                //add the images to the database
                foreach (var path in imagePaths)
                {
                    var image = new Image
                    {
                        Url = path,
                        ProductId = product.Id,
                    };
                    await _unitOfWork.Images.AddAsync(image);
                }
                _unitOfWork.Products.UpdateAsync(product);
                return Ok(product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetByIdAsync(Id, p => p.Images);
                if (product == null)
                {
                    return BadRequest("Product does not exist");
                }
                if (product.Images != null)
                {
                    foreach (var image in product.Images)
                    {
                        _imageManagementService.DeleteImageAsync(image.Url);
                        await _unitOfWork.Images.DeleteAsync(image.Id);
                    }
                }
                await _unitOfWork.Products.DeleteAsync(product.Id);
                await _unitOfWork.SaveAll();
                return Ok("Product deleted successfully");
            }
            catch (Exception ex)
            {
                {
                    return BadRequest(ex.Message);
                }
            }

        }
    }
}
    



