using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos
{
    public class DashboardResultDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<DashboardProductDto> Products { get; set; }
    }
}
