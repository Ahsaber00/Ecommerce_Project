using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Enums;
using Ecommerse_Project.DAL.Interfaces;
using Ecommerse_Project.DAL.Models.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _context;
        public OrderRepository(ApplicationContext context):base(context) 
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersByUserEmailAsync(string email)
        {
            var orders= await _context.Orders.Where(o => o.BuyerEmail == email).AsNoTracking().ToListAsync();
            return orders;
        }

        public async Task UpdateOrderStatusAsync(int orderId, Status newStatus)
        {
            var order=await _context.Orders.FirstOrDefaultAsync(o=>o.Id==orderId);
            if (order!=null)
            {
                order.Status = newStatus;
            }

        }
    }
}
