using System.ComponentModel.DataAnnotations;

namespace Ecommerse_Project.BLL.Dtos
{
    public class PaymentDto
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreatePaymentDto
    {
        [Required]
        public string OrderId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }
    }

    public class UpdatePaymentStatusDto
    {
        [Required]
        public string PaymentId { get; set; }

        [Required]
        public string Status { get; set; }

        public string TransactionId { get; set; }
    }
}