using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.BLL.Dtos.UserDtos
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }


    }
}
