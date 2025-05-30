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

            var buyerEmail = _httpContextAccessor.HttpContext.User.Claims
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderManager.GetAllOrdersAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("delivery-methods")]
        public async Task<IActionResult> GetDeliveryMethods()
        {
            try
            {
                var deliveryMethods = await _orderManager.GetDeliveryMethodsAsync();
                return Ok(deliveryMethods);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var buyerEmail = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
                if (buyerEmail == null)
                {
                    return NotFound("The user must be authenticated to view orders");
                }

                var order = await _orderManager.GetOrderById(id, buyerEmail);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user-orders")]
        public async Task<IActionResult> GetUserOrders()
        {
            try
            {
                var buyerEmail = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
                if (buyerEmail == null)
                {
                    return NotFound("The user must be authenticated to view orders");
                }

                var orders = await _orderManager.GetOrdersByUserEmailAsync(buyerEmail);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
