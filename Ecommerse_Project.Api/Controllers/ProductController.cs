using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Manager;
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
        private readonly IProductManager _productManager;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IImageManagementService imageManagementService,IProductManager productManager, ILogger<ProductController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageManagementService = imageManagementService;
            _productManager = productManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _productManager.GetAllProductsAsync();
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
                var result = await _productManager.GetByIdAsync(id);
                if(result == null)
                {
                    return NotFound();
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
                var newProduct=await _productManager.AddAsync(createProductDto);
               
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
                if(updateProductDto.Id != id)
                {
                    return BadRequest("Id mismatch.");
                }
                var product = await _productManager.UpdateAsync(updateProductDto);
                return Ok(product);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]int id)
        {
            try
            {
                _logger.LogInformation($"Attempting to delete product with ID: {id}.");

                var result = await _productManager.DeleteAsync(id);

                if (result)
                {
                    _logger.LogInformation($"Product with ID {id} deleted successfully.");
                    return Ok("Deleted Successfully.");
                }

                _logger.LogWarning($"Product with ID {id} not found.");
                return NotFound("Product not found");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while deleting product with ID {id}: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }
    }
}
    



