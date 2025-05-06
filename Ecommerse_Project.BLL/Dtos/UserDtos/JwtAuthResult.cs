using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos.UserDtos
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
