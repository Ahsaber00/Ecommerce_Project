using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Dtos.UserAuthenticationDtos;
using Ecommerse_Project.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;

namespace Ecommerse_Project.BLL.Manager
{
    public class UserAuthenticationManager : IuserAuthenticationManager
    {
        private readonly UserManager<ApplicationUser> _user;
       
        private readonly JwtSettings _jwtSettings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAuthenticationManager(UserManager<ApplicationUser> user, IOptions<JwtSettings> jwtSettings, IHttpContextAccessor httpContextAccessor)
        {
            _user = user;
            _jwtSettings = jwtSettings.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AccountDetailsDto> AccountDetails()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
           ;
            var user=await _user.FindByIdAsync(userId);
            if (user == null) {
                return null;
            }
            AccountDetailsDto accountDetails = new AccountDetailsDto
            {
                Email = user.Email
                ,
                Name = user.UserName

            };
            return accountDetails;
            

           
        }

        public async Task<string> Login(LoginDto login)
        {
    
            var user=await _user.FindByEmailAsync(login.Email);
            if (user == null) {return null;}
            var check_password=await _user.CheckPasswordAsync(user,login.Password);
            if (check_password == false) { return null; }
          var claims=await _user.GetClaimsAsync(user);
            return CreateToken(claims);
        
        }

        public async Task<string> Register(RegisterDto register,string Role)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = register.Name;
            user.Email = register.Email;
            var create_user =await _user.CreateAsync(user,register.Password);
            if (create_user.Succeeded)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name,register.Name));
                claims.Add(new Claim(ClaimTypes.Email,register.Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                claims.Add(new Claim(ClaimTypes.Role, Role));
                await _user.AddClaimsAsync(user, claims);
                return CreateToken(claims);
            }
            var errors = string.Join(" | ", create_user.Errors.Select(e => e.Description));
            throw new Exception($"User creation failed: {errors}");
            return null;
            
            
        }
        public string CreateToken(IList<Claim> claims)
        {
           
            var endcodeKey=Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var key = new SymmetricSecurityKey(endcodeKey);
            SigningCredentials credentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var ExpireDate=DateTime.UtcNow.AddDays(1);
            JwtSecurityToken jwtSecurity = new JwtSecurityToken(claims:claims,expires: ExpireDate, signingCredentials:credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token=handler.WriteToken(jwtSecurity);
            return token;
        }

        public async Task<AccountDetailsDto> UpdateAccount(UpdateAccountDto updateAccount)
        {
            var userId= _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a=>a.Type==ClaimTypes.NameIdentifier)?.Value;
           
            var user=await _user.FindByIdAsync(userId);
            user.UserName=updateAccount.Name;
            user.Email=updateAccount.Email;
            var checkOp=await _user.UpdateAsync(user);
            if (checkOp.Succeeded)
            {
                return new AccountDetailsDto
                {
                    Name = user.UserName,
                    Email = user.Email,
                };
               
            }
            return null;
           
        }
        public async Task<string>ChangePassword(PasswordChangeDto passwordChange)
        {
          
            var userId= _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(a=>a.Type==ClaimTypes.NameIdentifier)?.Value;  
            var user=await _user.FindByIdAsync(userId);
            if (user == null)
            {
                return "User not found.";
            } 
            var checkOldPassword = await _user.CheckPasswordAsync(user,passwordChange.OldPassword);
            if (checkOldPassword==false)
            {
                return "Invalid Password";
            }
            if (string.IsNullOrWhiteSpace(passwordChange.NewPassword) || passwordChange.NewPassword.Length < 6)
            {
                return "Password must be at least 6 characters long.";
            }
            var token = await _user.GeneratePasswordResetTokenAsync(user);
            var result = await _user.ResetPasswordAsync(user, token, passwordChange.NewPassword);
            if (!result.Succeeded)
            {
                return "Failed to change password: " + string.Join(", ", result.Errors.Select(e => e.Description));
            }
            return "password changed successfully";
        }
    }
}
