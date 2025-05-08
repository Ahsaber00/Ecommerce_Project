using Ecommerse_Project.DAL.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        [Required]
        public int MainCategoryId { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        // Gender-based
        public TargetAudience TargetAudience { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        //public string AdminID { get; set; }
        public IFormFileCollection Images { get; set; }
    }
}
