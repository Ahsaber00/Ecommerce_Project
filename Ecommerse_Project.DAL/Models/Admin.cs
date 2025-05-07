using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class Admin : ApplicationUser
    {

        public ICollection<Product> Products { get; set; }
        public Admin() { Role = Models.UserRole.Admin; }
    }
}
