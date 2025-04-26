using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var categories = await _unitOfWork.Categories.GetAllAsync();
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


        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            try
            {
                var category=await _unitOfWork.Categories.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
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
                Category newCategory = _mapper.Map<Category>(dto);
                await _unitOfWork.Categories.AddAsync(newCategory);
                await _unitOfWork.SaveAll();
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
                var category=_mapper.Map<Category>(dto);
                _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAll();

                return Ok(new { message = "Category updated successfully" });
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
                await _unitOfWork.Categories.DeleteAsync(id);
                await _unitOfWork.SaveAll();
                return Ok(new {massege= "Deleted successfully."});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }

}
