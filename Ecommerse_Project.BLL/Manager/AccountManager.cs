using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Ecommerse_Project.BLL.Dtos.UserDtos;
using Ecommerse_Project.BLL.Interfaces;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;

namespace Ecommerse_Project.BLL.Manager
{
    public class AccountManager:IaccountManager
    {
        private  readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _user;
        private readonly IGenericRepository<Address> _addressRepository;

        private readonly IUnitOfWork _unitOfWork;
        public AccountManager(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> user,IUnitOfWork unitOfWork, IGenericRepository<Address> addressRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _user = user;
           _unitOfWork = unitOfWork;
            _addressRepository = addressRepository;

        }
        public async Task<AddressDto> AddAddress(AddressDto addressDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _user.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var address = new Address
            {
                City = addressDto.City,
                Governorate = addressDto.Governorate,
                Country = addressDto.Country,
                Street = addressDto.Street,
                ApplicationUserId = userId,
            };


            await _addressRepository.AddAsync(address); // Await it properly
            await _unitOfWork.SaveAll();
            // Optionally: return the added address as DTO
            return new AddressDto
            {
                City = address.City,
                Governorate = address.Governorate,
                Country = address.Country,
                Street = address.Street
            };
        }
        public async Task<AddressDto> UpdateAddress(AddressDto addressDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _user.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }

            var user_adress =await _unitOfWork.Accounts.GetByIdAsync(userId,a=>a.Address);
            var adress=user_adress.Address.FirstOrDefault(a=>a.ApplicationUserId == userId);    
            if(adress == null) { return null; }
            adress.Street=addressDto.Street;
            adress.Governorate = addressDto.Governorate;
            adress.Country = addressDto.Country;
            adress.City = addressDto.City;
            await _unitOfWork.SaveAll();

            // Optionally: return the added address as DTO
            return addressDto;
           
        }

        public async Task<UpdateAccountDto> UpdateAccount(UpdateAccountDto updateAccount)
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _user.FindByIdAsync(userId);


            if (user == null) return null;


            bool isModified = false;

                user.FirstName = updateAccount.FirstName;
          

           
                user.LastName = updateAccount.LastName;
                
            

                user.PhoneNumber = updateAccount.phone;
          
          
                var update = await _user.UpdateAsync(user);

                if (!update.Succeeded)
                {
                    var errors = string.Join(", ", update.Errors.Select(e => e.Description));
                    throw new Exception($"Update failed: {errors}");
                }
            
         
               return  new UpdateAccountDto
               {
                   FirstName=user.FirstName,
                   LastName=user.LastName,  
                   
                    Email = user.Email
                    ,
                  
                    phone = user.PhoneNumber,

                };
            
            
        }
        public async Task<string> ChangePassword(PasswordChangeDto passwordChange)
        {

            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _user.FindByIdAsync(userId);
            if (user == null)
            {
                return "User not found.";
            }
            var checkOldPassword = await _user.CheckPasswordAsync(user, passwordChange.OldPassword);
            if (checkOldPassword == false)
            {
                return "Invalid Password";
            }
         
            var token = await _user.GeneratePasswordResetTokenAsync(user);
            var result = await _user.ResetPasswordAsync(user, token, passwordChange.NewPassword);
            if (!result.Succeeded)
            {
                return "Failed to change password: " + string.Join(", ", result.Errors.Select(e => e.Description));
            }
            return "password changed successfully";
        }
        public async Task<AccountDetailsDto> AccountDetails()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
            
            var user = await _user.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            var user_Adress=await _unitOfWork.Accounts.GetByIdAsync(userId,a=>a.Address);
            AccountDetailsDto accountDetails = new AccountDetailsDto
            {
                FirstName=user.FirstName
                ,
                LastName=user.LastName,
                Email = user.Email
                ,
                Name = user.UserName,
                phone=user.PhoneNumber,
                
                
                Address = user_Adress.Address.Select(a => new AddressDto
                {
                    Street = a.Street,
                    City = a.City,
                    Governorate = a.Governorate,
                    Country = a.Country
                }).ToList()


            };
            return accountDetails;



        }

    }

}
