using Ecommerse_Project.BLL.Dtos.UserAuthenticationDtos;
using Ecommerse_Project.BLL.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerse_Project.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthenticationController:ControllerBase
    {
        private readonly IuserAuthenticationManager _userManager;
        public UserAuthenticationController(IuserAuthenticationManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto,string role)
        {
            var RegisterToken = await _userManager.Register(registerDto,role);
            if (RegisterToken == null) { 
             return Unauthorized();
            }
            return Ok(RegisterToken);

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var LoginToken=await _userManager.Login(loginDto);
            if (LoginToken == null)
            {
                return Unauthorized();
            }
            return Ok(LoginToken);
        }
    

    }
}
