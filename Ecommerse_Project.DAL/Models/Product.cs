using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse_Project.DAL.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public DateTime AddedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }


        // ---------------- Additional Clothing Specific Fields ----------------
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Material { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }


        public int CategoryId { get; set; }
        public string AdminId { get; set; }

        //public virtual ICollection<CartProduct> Carts { get; set; }
        public virtual Category Category { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<WishListProduct> WishLists { get; set; }
       

    }
}
