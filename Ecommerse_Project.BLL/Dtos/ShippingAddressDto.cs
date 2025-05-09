using System.ComponentModel.DataAnnotations;

namespace Ecommerse_Project.BLL.Dtos
{
    public class ShippingAddressDto
    {
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
    }
}