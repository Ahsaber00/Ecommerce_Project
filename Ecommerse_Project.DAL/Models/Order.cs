using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerse_Project.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Precision(18, 2)]
        [Required]
        public decimal Cost { get; set; }
        [MaxLength(100)]
        public string Status {  get; set; }
        public DateTime Date { get; set; }
         public int CustomerId {  get; set; }
        public int AdressId {  get; set; }
        public int PaymentId {  get; set; }
        public int TrackingDetailsId {  get; set; }

    }
}
