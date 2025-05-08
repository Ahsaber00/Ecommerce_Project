using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.RedisModels
{
    [NotMapped]
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } // Optional
        public string ImageUrl { get; set; }
        [Precision(18, 2)]
        public decimal Price { get; set; } // Unit price
        public int Quantity { get; set; }

    }
}
