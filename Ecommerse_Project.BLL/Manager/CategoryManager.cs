using AutoMapper;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Category> AddAsync(CreateCategoryDto categoryDto)
        {
            var newCategory=_mapper.Map<Category>(categoryDto);
            
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.SaveAll();
            return newCategory;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category= await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null)
            {
                return false;
            }
            await _unitOfWork.Categories.DeleteAsync(id);
            await _unitOfWork.SaveAll();
            return true;
        }

        public async Task<IEnumerable<GetAllCategoriesDto>> GetAllAsync()
        {
            //return await _unitOfWork.Categories.GetAllAsync(c=>c.SubCategories);
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.SubCategories); // Include subcategories

            var categoryDtos = categories.Select(c => new GetAllCategoriesDto
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId,
                SubCategories = c.SubCategories
                    .Where(sc => sc.ParentCategoryId == c.Id)
                    .Select(sc => new SubCategoryDto
                    {
                        Id = sc.Id,
                        Name = sc.Name
                    }).ToList()
            }).ToList();

            return categoryDtos;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if(category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<Category> UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var category= _mapper.Map<Category>(categoryDto);
            _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAll();
            return category;
            
        }
    }
}
