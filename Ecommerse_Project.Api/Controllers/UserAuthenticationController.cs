
using Ecommerse_Project.BLL.Dtos.UserDtos;
using Ecommerse_Project.BLL.Manager;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerse_Project.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IuserAuthenticationManager _userManager;
        public UserAuthenticationController(IuserAuthenticationManager userManager)
        {

            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            AuthResult RegisterToken = await _userManager.Register(registerDto);
            if (RegisterToken.IsSuccess == false)
            {
                return BadRequest(new { message = RegisterToken.Message });
            }
            return Ok(new { token = RegisterToken.Token });

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            AuthResult LoginToken = await _userManager.Login(loginDto);
            if (!LoginToken.IsSuccess)
            {
                return Unauthorized(new { message = LoginToken.Message });
            }
            return Ok(new { token = LoginToken.Token });
        }
        //[HttpPost("Create")]
        //[Authorize(Roles = "Admin")] // Optional: secure it to Admins only
        //public async Task<IActionResult> CreateRole([FromBody] string roleName)
        //{
        //    if (string.IsNullOrWhiteSpace(roleName))
        //        return BadRequest("Role name must not be empty.");

        //    var roleExists = await _roleManager.RoleExistsAsync(roleName);
        //    if (roleExists)
        //        return BadRequest("Role already exists.");

        //    var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        //    if (result.Succeeded)
        //        return Ok($"Role '{roleName}' created successfully.");

        //    return BadRequest(result.Errors);
        //}



    }
}
