using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageFileName {  get; set; }
        public int ProductId {  get; set; }
        public virtual Product Product { get; set; }

    }
}
