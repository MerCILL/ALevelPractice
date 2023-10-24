using Module4HM1_WebApi.Models;
using Module4HM1_WebApi.Repositories.Interfaces;
using Module4HM1_WebApi.Services.Interfaces;

namespace Module4HM1_WebApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account GetAccount(string email)
        {
            return _accountRepository.GetAccount(email);
        }

        public async Task<Account> RegisterAsync(string email, string password)
        {
            var result = await _accountRepository.RegisterAsync(email, password);
            if (result == false) return null;
            return GetAccount(email);
        }

        public string Login(string email, string password)
        {
            return _accountRepository.Login(email, password);
        }

    }
}
