using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public interface IProductManager
    {
        Task<IEnumerable<GetAllProductDto>> GetAllProductsAsync();
        Task<ProductDetailsDto> GetByIdAsync(int id);
        Task<ProductDetailsDto> AddAsync(CreateProductDto productDto);
        Task<ProductDetailsDto>UpdateAsync(UpdateProductDto productDto);
        Task<bool> DeleteAsync(int id);
    }
}
