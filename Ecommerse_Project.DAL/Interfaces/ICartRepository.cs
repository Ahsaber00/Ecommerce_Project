using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.RedisModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Interfaces
{
    public interface ICartRepository
    {
        Task<CustomerCart> GetCartAsync(string userId);
        Task SaveCartAsync(string userId, CustomerCart cart);

    }
}
