using Ecommerse_Project.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos
{
    public class ProductFilterDto
    {
        public string? SearchTerm { get; set; }
        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }
        public TargetAudience? TargetAudience { get; set; }
        public List<string>? Sizes { get; set; }
        public List<string>? Colors { get; set; }
        public List<string>? Brands { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SortBy { get; set; } //  name, price-asc,price-desc
        public int ? PageNumber { get; set; } = 1;
        public int ? PageSize { get; set; } = 9;
    }
}
