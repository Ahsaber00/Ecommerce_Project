using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.RedisModels
{
    [NotMapped]
    public class CustomerCart
    {

        public int Id { get; set; }
        public string CustomerId { get; set; }
        public ICollection<CartItem> cartItems { get; set; }
        public decimal TotalPrice => cartItems!=null ? cartItems.Sum(i => i.Price * i.Quantity):0;

    }
}
