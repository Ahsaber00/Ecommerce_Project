using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.BLL.Dtos;

using Ecommerse_Project.BLL.Dtos.UserDtos;

namespace Ecommerse_Project.BLL.Manager
{
    public interface IuserAuthenticationManager
    {
        public Task<AuthResult> Login(LoginDto login);
        public Task<AuthResult> Register(RegisterDto register);



    }
}
