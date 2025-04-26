using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class CustomerProductReview
    {
        public int ProductId {  get; set; }
        public int CustomerId {  get; set; }
        public int Rating {  get; set; }
        public DateTime DateTime { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }

    }
}
