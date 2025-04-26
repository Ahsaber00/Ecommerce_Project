using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Name can't be longer than {1} characters")]
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email {  get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [MaxLength(25)]
        public string PhoneNumber {  get; set; }
        public DateTime RegisterDate {  get; set; }
        public Cart Carts { get; set; }
        public ICollection<Wishlist> Wishlist { get; set; }
        public ICollection<CustomerProductReview> ProductReviews { get; set; }
        public ICollection<Order> OrderList { get; set; }
        public ICollection<Address>Addresses { get; set; }
        


    }
}
