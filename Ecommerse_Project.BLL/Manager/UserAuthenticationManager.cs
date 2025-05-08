using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.BLL.Dtos;

using Ecommerse_Project.BLL.Dtos.UserDtos;
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
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly JwtSettings _jwtSettings;

        public UserAuthenticationManager(UserManager<ApplicationUser> user, IOptions<JwtSettings> jwtSettings, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _user = user;
            _jwtSettings = jwtSettings.Value;

        }


        private List<Claim> GetStaticClaims(ApplicationUser user)
        {
            return new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Role, user.Role.ToString())
    };
        }
        public async Task<AuthResult> Login(LoginDto login)
        {

            var user = await _user.FindByEmailAsync(login.Email);
            if (user == null) { return new AuthResult { IsSuccess = false, Message = "Invalid email or password" }; }
            var check_password = await _user.CheckPasswordAsync(user, login.Password);
            if (check_password == false) { return new AuthResult { IsSuccess = false, Message = "Invalid email or password" }; }
            var claims = GetStaticClaims(user);
            var token = CreateToken(claims);
            return new AuthResult { IsSuccess = true, Token = token.AccessToken };

        }

        public async Task<AuthResult> Register(RegisterDto register)
        {
            ApplicationUser user = new Admin();

            user.UserName = register.Name;
            user.Email = register.Email;

            var create_user = await _user.CreateAsync(user, register.Password);

            if (create_user.Succeeded)
            {
                // Set role after successful creation

                var defaultRole = user.Role.ToString();
                if (!await _roleManager.RoleExistsAsync(defaultRole))
                {
                    await _roleManager.CreateAsync(new IdentityRole(defaultRole));
                }
                var add_role = await _user.AddToRoleAsync(user, defaultRole);

                var claims = GetStaticClaims(user);
                await _user.AddClaimsAsync(user, claims);

                var token = CreateToken(claims);
                return new AuthResult { IsSuccess = true, Token = token.AccessToken };
            }

            var errors = string.Join(" | ", create_user.Errors.Select(e => e.Description));
            return new AuthResult { IsSuccess = false, Message = $"User creation failed: {errors}" };
        }
        public JwtAuthResult CreateToken(IList<Claim> claims)
        {

            var endcodeKey = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var key = new SymmetricSecurityKey(endcodeKey);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(_jwtSettings.DurationInDays);
            var jwtSecurity = new JwtSecurityToken(
                           issuer: _jwtSettings.Issuer,
                           audience: _jwtSettings.Audience,
                           claims: claims,
                           expires: expireDate,
                           signingCredentials: credentials
                                                     );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = handler.WriteToken(jwtSecurity);
            return new JwtAuthResult { AccessToken = token, ExpireAt = expireDate };
        }

    }
}
