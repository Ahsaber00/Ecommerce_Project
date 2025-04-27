using Ecommerse_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Interfaces
{
    public interface ICartProductRepository
    {
        Task<CartProduct> GetCartProductAsync(int cartId, int productId);
        Task AddCartProductAsync(int cartId, int productId, int quantity);
        Task RemoveCartProductAsync(int cartId, int productId);
        Task UpdateCartProductQuantityAsync(int cartId, int productId, int quantity);
        Task<List<CartProduct>> GetProductsInCartAsync(int cartId);
    }

}
