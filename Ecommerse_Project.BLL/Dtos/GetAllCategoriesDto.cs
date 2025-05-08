using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos
{
    public class GetAllCategoriesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<SubCategoryDto>? SubCategories { get; set; } = new List<SubCategoryDto>();


    }
}
