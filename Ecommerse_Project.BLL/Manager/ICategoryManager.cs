using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public interface ICategoryManager
    {
        Task<IEnumerable<GetAllCategoriesDto>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> AddAsync(CreateCategoryDto category);
        Task<Category> UpdateAsync(UpdateCategoryDto category);
        Task<bool> DeleteAsync(int id);
    }
}
