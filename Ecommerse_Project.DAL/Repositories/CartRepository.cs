using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using Ecommerse_Project.DAL.RedisModels;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Repositories
{
    public class CartRepository : ICartRepository
    {
        
        private readonly IDatabase _database;
        public CartRepository(IConnectionMultiplexer redis)
        {
            _database =redis.GetDatabase();
            
        }

        public async Task<CustomerCart> GetCartAsync(string userId)
        {
            var cartData= await _database.StringGetAsync(userId);
            return cartData.IsNullOrEmpty  ? new CustomerCart { CustomerId = userId } : JsonSerializer.Deserialize<CustomerCart>(cartData);
        }

        public async Task SaveCartAsync(string userId, CustomerCart cart)
        {
            var jsonCart=JsonSerializer.Serialize(cart);

            //stores the data with the user id as key
           await _database.StringSetAsync(userId, jsonCart,TimeSpan.FromDays(1));
        }
    }
}
