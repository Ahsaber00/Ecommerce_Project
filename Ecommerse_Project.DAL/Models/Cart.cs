using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class Cart
    {
        public int Id { get; set; } 
        public int CustomerId {  get; set; }
        public ICollection<CartProduct> Products { get; set; }

    }
}
