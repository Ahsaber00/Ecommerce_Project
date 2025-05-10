using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Manager;
using Ecommerse_Project.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce__Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public OrdersController(IOrderManager orderManager, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _orderManager = orderManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreatOrder(CreateOrderDto orderDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims
               .FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return NotFound("The user must be authenticated to make an order");
            }

            var buyerEmail= _httpContextAccessor.HttpContext.User.Claims
               .FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
            if (userId == null)
            {
                return NotFound("The user must be authenticated to make an order");
            }

            var createdOrder = await _orderManager.CreateOrderAsync(orderDto, buyerEmail, userId);
            if (createdOrder == null)
            {
                return BadRequest("Failed to create the order");
            }
            return Ok(createdOrder);


        }

    }
}
