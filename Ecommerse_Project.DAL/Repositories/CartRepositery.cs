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
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly ApplicationContext _context;

        public CartRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartByCustomerIdAsync(int customerId)
        {
            return await _context.Carts
                .Include(c => c.Products)
                    .ThenInclude(cp => cp.Product)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task AddProductToCartAsync(int cartId, int productId, int quantity)
        {
            var cartProduct = await _context.CartProducts
                .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);

            if (cartProduct != null)
            {
                cartProduct.Quantity += quantity;
            }
            else
            {
                cartProduct = new CartProduct
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = quantity
                };
                await _context.CartProducts.AddAsync(cartProduct);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveProductFromCartAsync(int cartId, int productId)
        {
            var cartProduct = await _context.CartProducts
                .FirstOrDefaultAsync(cp => cp.CartId == cartId && cp.ProductId == productId);

            if (cartProduct != null)
            {
                _context.CartProducts.Remove(cartProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckoutAsync(int customerId)
        {
            var cart = await GetCartByCustomerIdAsync(customerId);
            if (cart == null) throw new Exception("Cart not found");

            // Example: Clear the cart after checkout
            _context.CartProducts.RemoveRange(cart.Products);
            await _context.SaveChangesAsync();
        }

        // Create a new cart for a customer
        public async Task<Cart> CreateCartAsync(int customerId)
        {
            var cart = new Cart
            {
                CustomerId = customerId,
                Products = new List<CartProduct>() // Initially, the cart has no products
            };

            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();

            return cart; // Return the created cart
        }
    }


}
