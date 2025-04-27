using Ecommerse_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos
{
    public class CartProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } // For easier frontend display
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
