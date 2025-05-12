using Ecommerse_Project.BLL.Interfaces;
using Ecommerse_Project.DAL.Enums;
using Ecommerse_Project.DAL.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IReadOnlyList<Order>> GetOrdersByUserEmailAsync(string email);
        Task UpdateOrderStatusAsync(int orderId, Status newStatus);
    }
}
