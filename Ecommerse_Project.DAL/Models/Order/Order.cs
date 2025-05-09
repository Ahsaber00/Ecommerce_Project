using Ecommerse_Project.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Models.Order
{
    public class Order
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public decimal OrderPrice {  get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public ShippingAddress ShippingAddress { get; set; }
        public int DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public Status Status { get; set; }=Status.Pending;
        public decimal GetTotalPrice()
        {
            return OrderPrice+DeliveryMethod.Price;
        }
        
    }
}
