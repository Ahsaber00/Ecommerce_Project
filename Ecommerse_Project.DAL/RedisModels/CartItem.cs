using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.RedisModels
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } // Optional
        public string ImageUrl { get; set; } 
        public decimal Price { get; set; } // Unit price
        public int Quantity { get; set; }

    }
}
