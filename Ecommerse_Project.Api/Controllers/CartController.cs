using Ecommerse_Project.BLL.Manager;
using Ecommerse_Project.DAL.RedisModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce__Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartManager _cartManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(ICartManager cartManager, IHttpContextAccessor httpContextAccessor)
        {
            _cartManager = cartManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCart()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims
               .FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentException("The user must be authenticated to use cart.");
            }
            var cart =await _cartManager.GetCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddtoCart([FromBody]CartItem cartItem)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims
               .FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentException("The user must be authenticated to use cart.");
            }
            await _cartManager.AddToCartAsync(userId,cartItem);
            return Ok("Item is added to cart successfully.");
        }

        [HttpDelete("{productId:int}")]
        public async Task<IActionResult> DeleteItemFromCart([FromRoute]int productId)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims
              .FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentException("The user must be authenticated to use cart.");
            }
            await _cartManager.RemoveFromCartAsync(userId, productId);
            return Ok("Item Deleted successfully");
        }




    }
}
