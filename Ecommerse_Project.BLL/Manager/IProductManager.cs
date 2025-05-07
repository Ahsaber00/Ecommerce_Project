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
        Task<DashboardResultDto> GetAllProductsDashboardAsync(DashboardPaginationProductsDto pagination);
        Task<PaginatedProductResultDto> GetAllProductsAsync(ProductFilterDto? filter);
        Task<ProductDetailsDto> GetByIdAsync(int id);
        Task<ProductDetailsDto> AddAsync(string AdminId,CreateProductDto productDto);
        Task<ProductDetailsDto>UpdateAsync(string AdminId,UpdateProductDto productDto);
        Task<bool> DeleteAsync(int id);
    }
}
