using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class Address
    {


        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }    
        public string Governorate { get; set; }
        [MaxLength(100)]
        [Required]
        public string City { get; set; }
        [MaxLength(100)]
        [Required]
        public string Street { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Buyer { get; set; }

    }
}
