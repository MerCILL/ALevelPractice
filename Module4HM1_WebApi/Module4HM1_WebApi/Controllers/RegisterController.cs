using Microsoft.AspNetCore.Mvc;
using Module4HM1_WebApi.Models;
using Module4HM1_WebApi.Services.Interfaces;

namespace Module4HM1_WebApi.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        public RegisterController(IAccountService accountService, IUserService userService) 
        {
            _accountService = accountService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterAsync(AccountRegisterModel account)
        {
            if (string.IsNullOrEmpty(account.Email)) return BadRequest("Email can't be empty");
            if (string.IsNullOrEmpty(account.Password)) return BadRequest("Password can't be empty");

            var existingUser = await _userService.GetUserByEmail(account.Email);
            if (existingUser == null) 
            {            
                var newAccount = await  _accountService.RegisterAsync(account.Email, account.Password);
                var newUser = new User("", "", account.Email);
                await _userService.CreateAsync(newUser);
                return Ok(new {newUser.Id, newAccount.Token});
            }
            else
            {
                return BadRequest(existingUser.Id);
            }

        }

    }
}