using Ecommerse_Project.BLL.Dtos;
using Ecommerse_Project.BLL.Dtos.UserAuthenticationDtos;
using Ecommerse_Project.BLL.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerse_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     [Authorize]
    public class UserController:ControllerBase
    {
        private readonly IuserAuthenticationManager _userManager;
            public UserController(IuserAuthenticationManager userManager)
        {
            _userManager = userManager;
        }
        [HttpPut("UpdateAccoun")]
        public async Task<IActionResult> UpdateAccount(UpdateAccountDto updateAccountDto)
        {
            var UpdateUser = await _userManager.UpdateAccount(updateAccountDto);
            if (UpdateAccount == null) { return NoContent(); }
            return Ok(UpdateUser);
        }
        [HttpGet("AccountDetails")]
       
        public async Task<IActionResult> AccountDetails()
        {
            var accountDetails = await _userManager.AccountDetails();
            if (accountDetails == null) { return NotFound(); }

            return Ok(accountDetails);

        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(PasswordChangeDto passwordChange)
        {
            var changestatus =await _userManager.ChangePassword(passwordChange);
            if(changestatus == null) {return BadRequest("failed to change password");}

            return Ok(changestatus);
        }

    }
}
