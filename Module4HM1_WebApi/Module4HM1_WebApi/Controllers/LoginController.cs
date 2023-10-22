using Microsoft.AspNetCore.Mvc;
using Module4HM1_WebApi.Models;
using Module4HM1_WebApi.Services.Interfaces;

namespace Module4HM1_WebApi.Controllers
{
    [ApiController]
    [Route("/api/login")]
    public class LoginController : ControllerBase
    {
        IAccountService _accountService;

        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public ActionResult Login(AccountRegisterModel accountRegisterModel)
        {
            var result = _accountService.Login(accountRegisterModel.Email, accountRegisterModel.Password);
            var account = _accountService.GetAccount(accountRegisterModel.Email);
            if (account == null || result != account.Token.ToString()) return BadRequest(result);
            return Ok(result);
        }

    }
}
