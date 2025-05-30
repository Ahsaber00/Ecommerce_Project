using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Interfaces;
using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ecommerce__Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSoftDeleteController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;

        public TestSoftDeleteController(
            ApplicationContext context,
            IHttpContextAccessor httpContext,
            IGenericRepository<Product> productRepository,
            IGenericRepository<Category> categoryRepository)
        {
            _context = context;
            _httpContextAccessor = httpContext;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost("test-product")]
        public async Task<IActionResult> TestProductSoftDelete()
        {
            try
            {
                var AdminId = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
                if (AdminId == null)
                {
                    throw new ArgumentException("The Admin must be authenticated to add a product.");
                }

                // 1. Create a test product
                var product = new Product
                {
                    Name = "Test Product",
                    Description = "Test Description",
                    Price = 100,
                    Stock = 10,
                    Brand = "Test Brand",
                    Material = "Test Material",
                    AdminId = AdminId,
                    Color = "red"
                };
                await _productRepository.AddAsync(product);
                await _context.SaveChangesAsync();

                // 2. Get the product to verify it exists
                var createdProduct = await _productRepository.GetByIdAsync(product.Id);
                if (createdProduct == null)
                    return BadRequest("Failed to create test product");

                // 3. Soft delete the product using the new method
                await _productRepository.SoftDeleteAsync(product.Id);
                await _context.SaveChangesAsync();

                // 4. Try to get the product again - should return null due to soft delete
                var deletedProduct = await _productRepository.GetByIdAsync(product.Id);
                if (deletedProduct != null)
                    return BadRequest("Product was not soft deleted");

                // 5. Get the product directly from database to verify it still exists
                var productInDb = await _context.Products
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(p => p.Id == product.Id);

                if (productInDb == null)
                    return BadRequest("Product was hard deleted instead of soft deleted");

                return Ok(new
                {
                    Message = "Soft delete test successful",
                    ProductId = product.Id,
                    IsDeleted = productInDb.IsDeleted,
                    DeletedAt = productInDb.DeletedAt
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, stackTrace = ex.StackTrace });
            }
        }

        [HttpPost("test-category")]
        public async Task<IActionResult> TestCategorySoftDelete()
        {
            try
            {
                // 1. Create a test category
                var category = new Category
                {
                    Name = "Test Category"
                };
                await _categoryRepository.AddAsync(category);
                await _context.SaveChangesAsync();

                // 2. Get the category to verify it exists
                var createdCategory = await _categoryRepository.GetByIdAsync(category.Id);
                if (createdCategory == null)
                    return BadRequest("Failed to create test category");

                // 3. Soft delete the category using the new method
                await _categoryRepository.SoftDeleteAsync(category.Id);
                await _context.SaveChangesAsync();

                // 4. Try to get the category again - should return null due to soft delete
                var deletedCategory = await _categoryRepository.GetByIdAsync(category.Id);
                if (deletedCategory != null)
                    return BadRequest("Category was not soft deleted");

                // 5. Get the category directly from database to verify it still exists
                var categoryInDb = await _context.Categories
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(c => c.Id == category.Id);

                if (categoryInDb == null)
                    return BadRequest("Category was hard deleted instead of soft deleted");

                return Ok(new
                {
                    Message = "Soft delete test successful",
                    CategoryId = category.Id,
                    IsDeleted = categoryInDb.IsDeleted,
                    DeletedAt = categoryInDb.DeletedAt
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, stackTrace = ex.StackTrace });
            }
        }

        [HttpGet("verify-soft-delete")]
        public async Task<IActionResult> VerifySoftDelete(int id, string type)
        {
            switch (type.ToLower())
            {
                case "product":
                    var product = await _context.Products
                        .IgnoreQueryFilters()
                        .FirstOrDefaultAsync(p => p.Id == id);
                    if (product == null)
                        return NotFound("Product not found");
                    return Ok(new
                    {
                        Id = product.Id,
                        Name = product.Name,
                        IsDeleted = product.IsDeleted,
                        DeletedAt = product.DeletedAt,
                        CreatedAt = product.AddedAt,
                        UpdatedAt = product.UpdatedAt
                    });

                case "category":
                    var category = await _context.Categories
                        .IgnoreQueryFilters()
                        .FirstOrDefaultAsync(c => c.Id == id);
                    if (category == null)
                        return NotFound("Category not found");
                    return Ok(new
                    {
                        Id = category.Id,
                        Name = category.Name,
                        IsDeleted = category.IsDeleted,
                        DeletedAt = category.DeletedAt,
                        CreatedAt = category.AddedAt,
                        UpdatedAt = category.UpdatedAt
                    });

                default:
                    return BadRequest("Invalid type. Use 'product' or 'category'");
            }
        }
    }
}