namespace Ecommerse_Project.BLL.Dtos
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductMainImage { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}