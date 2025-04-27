using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Ecommerse_Project.DAL.Repositories
{
    public class CartProductRepository : ICartProductRepository
    {
        private readonly ApplicationContext _context;

        public CartProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<CartProduct> GetCartProductAsync(int cartId, int productId)
        {
            return await _context.CartProducts
                .Include(cp => cp.Product)
                .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);
        }

        public async Task AddCartProductAsync(int cartId, int productId, int quantity)
        {
            var cartProduct = new CartProduct
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };

            await _context.CartProducts.AddAsync(cartProduct);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCartProductAsync(int cartId, int productId)
        {
            var cartProduct = await GetCartProductAsync(cartId, productId);
            if (cartProduct != null)
            {
                _context.CartProducts.Remove(cartProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCartProductQuantityAsync(int cartId, int productId, int quantity)
        {
            var cartProduct = await GetCartProductAsync(cartId, productId);
            if (cartProduct != null)
            {
                cartProduct.Quantity = quantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CartProduct>> GetProductsInCartAsync(int cartId)
        {
            return await _context.CartProducts
                .Where(cp => cp.CartId == cartId)
                .Include(cp => cp.Product)
                .ToListAsync();
        }
    }

}
