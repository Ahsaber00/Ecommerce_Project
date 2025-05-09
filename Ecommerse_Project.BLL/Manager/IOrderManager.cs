using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.DAL.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Manager
{
    public interface IOrderManager
    {
        Task<IReadOnlyList<OrderResultDto>> GetAllOrdersAsync();
        Task<OrderResultDto> CreateOrderAsync(CreateOrderDto orderDto, string buyerEmail,string userid);
        Task<IReadOnlyList<OrderResultDto>> GetOrdersByUserEmailAsync(string email);
        Task<Order> GetOrderById(int orderId,string buyerEmail);
        Task<List<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
