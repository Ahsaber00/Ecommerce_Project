using Ecommerse_Project.BLL.Interfaces;
using Ecommerse_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Interfaces
{
    // ICartRepository.cs
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCartByCustomerIdAsync(int customerId);
        Task AddProductToCartAsync(int cartId, int productId, int quantity);
        Task RemoveProductFromCartAsync(int cartId, int productId);
        Task CheckoutAsync(int customerId);

        // Added CreateCartAsync method
        Task<Cart> CreateCartAsync(int customerId);
    }


}
