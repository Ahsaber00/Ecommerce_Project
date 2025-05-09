using Ecommerse_Project.DAL.Models.Order;

namespace Ecommerse_Project.BLL.Dtos
{
    public class CreateOrderDto
    {
        public int DeliveryMethodId {  get; set; }
        public int CartId {  get; set; }
        public ShippingAddressDto ShippingAddress { get; set; }
    }
}