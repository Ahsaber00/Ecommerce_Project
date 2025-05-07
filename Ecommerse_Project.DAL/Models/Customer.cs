using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.DAL.Models;
using Ecommerse_Project.DAL.RedisModels;

namespace Ecommerse_Project.DAL.Entities
{
    public class Customer : ApplicationUser
    {



        public DateTime RegisterDate { get; set; }
        public CustomerCart Carts { get; set; }
        public ICollection<Wishlist> Wishlist { get; set; }
      
        public ICollection<Order> OrderList { get; set; }
       
        public Customer() { Role = UserRole.Customer; }



    }
}
