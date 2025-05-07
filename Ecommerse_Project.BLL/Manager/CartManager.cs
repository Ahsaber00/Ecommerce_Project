using Ecommerse_Project.DAL.Interfaces;
using Ecommerse_Project.DAL.RedisModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public class CartManager : ICartManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartManager(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task AddToCartAsync(string userId,CartItem cartItem)
        {
            
            var cart=await _unitOfWork.CustomerCart.GetCartAsync(userId);
            var existingItem = cart.cartItems.FirstOrDefault(p => p.ProductId == cartItem.ProductId);
            if (existingItem!=null)
            {
                existingItem.Quantity += cartItem.Quantity;
            }
            else
            { 
                cart.cartItems.Add(cartItem);
            }
           await _unitOfWork.CustomerCart.SaveCartAsync(userId,cart);
        }

        public async Task<CustomerCart> GetCartAsync(string userId)
        {
            
            return await _unitOfWork.CustomerCart.GetCartAsync(userId);
        }

        public async Task RemoveFromCartAsync(string userId,int productId)
        {
            var cart= await _unitOfWork.CustomerCart.GetCartAsync(userId);
            var existingItem= cart.cartItems.FirstOrDefault(p=>p.ProductId==productId);
            if(existingItem!=null)
            {
                cart.cartItems.Remove(existingItem);
                await _unitOfWork.CustomerCart.SaveCartAsync(userId, cart);
            }
            
        }
    }
}
