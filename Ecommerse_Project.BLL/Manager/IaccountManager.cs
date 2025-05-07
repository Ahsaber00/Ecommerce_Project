using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerse_Project.BLL.Dtos.UserDtos;

namespace Ecommerse_Project.BLL.Manager
{
    public interface  IaccountManager
    {
        public Task<AccountDetailsDto> AccountDetails();
        public Task<UpdateAccountDto> UpdateAccount(UpdateAccountDto updateAccount);
        public Task<string> ChangePassword(PasswordChangeDto password) ;
        public  Task<AddressDto> AddAddress(AddressDto addressDto);
        public Task<AddressDto> UpdateAddress(AddressDto addressDto);
    }
}
