using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos
{
    public class OrderResultDto
    {
        public int OrderId { get; set; }
        public string BuyerEmail { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }

        public string DeliveryMethod { get; set; }
        public decimal DeliveryPrice { get; set; }

        public ShippingAddressDto ShippingAddress { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
