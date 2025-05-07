using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ecommerse_Project.BLL.Dtos
{
    public class GetAllProductDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<ImageDto> Images { get; set; }
    }
}
