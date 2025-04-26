using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Dtos.UserAuthenticationDtos;

namespace Ecommerse_Project.BLL.Manager
{
    public interface IuserAuthenticationManager
    {
        public Task<string> Login(LoginDto login);
        public Task<string> Register(RegisterDto register,string Role);
        public Task<AccountDetailsDto> AccountDetails();
        public Task<AccountDetailsDto>UpdateAccount(UpdateAccountDto updateAccount);
        public Task<string> ChangePassword(PasswordChangeDto password)
        ;

        

    }
}
