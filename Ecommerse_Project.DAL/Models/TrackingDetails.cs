using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class TrackingDetails
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Status {  get; set; }
        public Order Order { get; set; }

    }
}
