using System.ComponentModel.DataAnnotations;

namespace Ecommerse_Project.DAL.Models.Order
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Governorate { get; set; }
        [MaxLength(100)]
        [Required]
        public string City { get; set; }
        [MaxLength(100)]
        [Required]
        public string Street { get; set; }
        public int OrderId {  get; set; }
        public virtual Order Order { get; set; }
    }
}