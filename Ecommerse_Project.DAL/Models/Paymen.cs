using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse_Project.DAL.Entities
{
    public class Paymen
    {
        public int Id { get; set; }
        [Precision(18, 2)]
        [Required]
        public decimal Amount {  get; set; }
        [Required]
        [MaxLength(100)]
        public string PaymentMethod {  get; set; }
        public Order Order { get; set; }

    }
}
