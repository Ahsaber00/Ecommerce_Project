using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        [MaxLength(100)]
        
        public string Name { get; set; }
        [MaxLength(100)]
        public string Password {  get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
