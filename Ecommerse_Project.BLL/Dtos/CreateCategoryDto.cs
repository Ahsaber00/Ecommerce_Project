using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }

        // This must be provided to indicate whether it's under "Men" or "Women"
        public int ParentCategoryId { get; set; }
    }
}
