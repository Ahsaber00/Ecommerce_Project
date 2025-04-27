using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Manager;

namespace Ecommerse_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartManager _cartManager;

        public CartController(CartManager cartManager)
        {
            _cartManager = cartManager;
        }

        // POST: /api/cart
        [HttpPost]
        public async Task<IActionResult> CreateCart([FromBody] int customerId)
        {
            try
            {
                var cart = await _cartManager.CreateCartAsync(customerId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: /api/cart/add-product
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProductToCart([FromBody] AddProductToCartDto addProductDto)
        {
            try
            {
                var cart = await _cartManager.AddProductToCartAsync(addProductDto);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: /api/cart/remove-product
        [HttpDelete("remove-product")]
        public async Task<IActionResult> RemoveProductFromCart([FromBody] RemoveProductFromCartDto removeProductDto)
        {
            try
            {
                var cart = await _cartManager.RemoveProductFromCartAsync(removeProductDto);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: /api/cart/{customerId}
        [HttpGet("{customerId:int}")]
        public async Task<IActionResult> GetCart([FromRoute] int customerId)
        {
            try
            {
                var cart = await _cartManager.GetCartAsync(customerId);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: /api/cart/checkout
        [HttpPost("checkout")]
        public async Task<IActionResult> CheckoutCart([FromBody] int cartId)
        {
            try
            {
                await _cartManager.CheckoutAsync(cartId);
                return Ok(new { message = "Checkout completed successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}