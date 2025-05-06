
using Ecommerse_Project.BLL.Dtos.UserDtos;
using Ecommerse_Project.BLL.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerse_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController:ControllerBase
    {
        private readonly IaccountManager _userManager;
            public AccountController(IaccountManager userManager)
        {
            _userManager = userManager;
        }
        [HttpPut("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount(UpdateAccountDto updateAccountDto)
        {
            var UpdateUser = await _userManager.UpdateAccount(updateAccountDto);
            if (UpdateUser == null) { return NoContent(); }
            return Ok(UpdateUser);
        }
        [HttpGet("AccountDetails")]
       
        public async Task<IActionResult> AccountDetails()
        {
            var accountDetails = await _userManager.AccountDetails();
            if (accountDetails == null) { return null; }

            return Ok(accountDetails);

        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(PasswordChangeDto passwordChange)
        {
            var changestatus =await _userManager.ChangePassword(passwordChange);
            if(changestatus == null) {return BadRequest("failed to change password");}

            return Ok(changestatus);
        }
        [HttpPost("AddAddress")]
        public async Task<IActionResult>AddAddress(AddressDto address)
        {
            var add_=await _userManager.AddAddress(address);
            if (add_ == null) {
                return BadRequest("failed to Add Address");
            }
            return Ok(add_);
        }
        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress(AddressDto address)
        {
            var add_ = await _userManager.UpdateAddress(address);
            if (add_ == null)
            {
                return BadRequest("failed to Update Address");
            }
            return Ok(add_);
        }
    }
}
