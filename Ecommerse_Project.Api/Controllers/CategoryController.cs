using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Manager;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using Ecommerse_Project.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce__Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var categories = await _categoryManager.GetAllAsync();
                if (categories == null)
                {
                    return BadRequest();
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            try
            {
                var category=await _categoryManager.GetByIdAsync(id);
                //if (category == null)
                //{
                //    return NotFound();
                //}
                return Ok(category);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateCategoryDto dto)
        {
            try
            {
                var newCategory=await _categoryManager.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new {id=newCategory.Id},newCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryDto dto)
        {
            try
            {
                var updatedCategory=await _categoryManager.UpdateAsync(dto);
                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute]int id)
        {
            try
            {
               var result= await _categoryManager.DeleteAsync(id);
                if (result)
                {
                    return Ok(new { massege = "Deleted successfully." });
                }
                return BadRequest("Category not found");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

}
