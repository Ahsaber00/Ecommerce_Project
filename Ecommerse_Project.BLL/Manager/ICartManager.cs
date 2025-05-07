using Ecommerse_Project.DAL.RedisModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public interface ICartManager
    {
        Task AddToCartAsync(string UserId,CartItem cartItem);
        Task<CustomerCart> GetCartAsync(string userId);
        Task RemoveFromCartAsync(string userId,int productId);
    }
}
