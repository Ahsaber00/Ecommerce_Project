using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public class CartManager
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository; // Using CartProductRepository

        public CartManager(ICartRepository cartRepository, ICartProductRepository cartProductRepository)
        {
            _cartRepository = cartRepository;
            _cartProductRepository = cartProductRepository;
        }

        // Create a new cart for a customer
        public async Task<CartDto> CreateCartAsync(int customerId)
        {
            var cart = new CartDto
            {
                CustomerId = customerId,
                Products = new List<CartProductDto>()
            };

            // Save the new cart
            var savedCart = await _cartRepository.CreateCartAsync(customerId);
            cart.CustomerId = savedCart.CustomerId;
            cart.Products = savedCart.Products.Select(p => new CartProductDto
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList();

            return cart;
        }

        // Add a product to the cart
        public async Task<CartDto> AddProductToCartAsync(AddProductToCartDto addProductDto)
        {
            // Check if the product exists before adding (optional, depending on the use case)
            var cartProduct = await _cartProductRepository.GetCartProductAsync(addProductDto.CartId, addProductDto.ProductId);

            if (cartProduct != null)
            {
                // If product is already in the cart, update quantity
                await _cartProductRepository.UpdateCartProductQuantityAsync(addProductDto.CartId, addProductDto.ProductId, cartProduct.Quantity + addProductDto.Quantity);
            }
            else
            {
                // If product isn't in the cart, add it
                await _cartProductRepository.AddCartProductAsync(addProductDto.CartId, addProductDto.ProductId, addProductDto.Quantity);
            }

            // Get the updated cart
            var cartEntity = await _cartRepository.GetCartByCustomerIdAsync(addProductDto.CartId);

            var cartDto = new CartDto
            {
                CustomerId = cartEntity.CustomerId,
                Products = cartEntity.Products.Select(p => new CartProductDto
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };

            return cartDto;
        }

        // Remove a product from the cart
        public async Task<CartDto> RemoveProductFromCartAsync(RemoveProductFromCartDto removeProductDto)
        {
            await _cartProductRepository.RemoveCartProductAsync(removeProductDto.CartId, removeProductDto.ProductId);

            // Get the updated cart
            var cartEntity = await _cartRepository.GetCartByCustomerIdAsync(removeProductDto.CartId);

            // Map to CartDto
            var cartDto = new CartDto
            {
                CustomerId = cartEntity.CustomerId,
                Products = cartEntity.Products.Select(p => new CartProductDto
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };

            return cartDto;
        }

        // Get a customer's cart with all products
        public async Task<CartDto> GetCartAsync(int customerId)
        {
            var cartEntity = await _cartRepository.GetCartByCustomerIdAsync(customerId);
            if (cartEntity == null)
            {
                throw new Exception("Cart not found.");
            }

            // Map to CartDto
            var cartDto = new CartDto
            {
                CustomerId = cartEntity.CustomerId,
                Products = cartEntity.Products.Select(p => new CartProductDto
                {
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };

            return cartDto;
        }

        // Checkout and place an order
        public async Task CheckoutAsync(int cartId)
        {
            var cart = await _cartRepository.GetCartByCustomerIdAsync(cartId);
            if (cart == null || !cart.Products.Any())
            {
                throw new Exception("Cart is empty or not found.");
            }

           
            

            // Clear the cart after checkout
            await _cartRepository.CheckoutAsync(cart.CustomerId);

         
        }
    }


}
