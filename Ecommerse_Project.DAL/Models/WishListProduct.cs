using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class WishListProduct
    {
        public int ProductId { get; set; }  
        public int WishlistId {  get; set; }
        public DateTime DateTime { get; set; }
        public Product Product { get; set; }
        public Wishlist Wishlist { get; set; }
    }
}
