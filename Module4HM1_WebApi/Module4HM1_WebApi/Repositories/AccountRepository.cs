using Module4HM1_WebApi.Models;
using Module4HM1_WebApi.Repositories.Interfaces;
using Module4HM1_WebApi.Services.Interfaces;

namespace Module4HM1_WebApi.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private static Dictionary<string, Account> _accounts = new();
        private readonly IUserService _userService;

        public AccountRepository(IUserService userService) 
        {
            _userService = userService;
        }

        public Account GetAccount(string email)
        {
            _accounts.TryGetValue(email, out var account);
            return account;
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var result = _accounts.TryAdd(email, new Account(email, password));
            return result;
        }

        public string Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return "Email or password is empty";

            if (_accounts.ContainsKey(email))
            {
                var account = _accounts[email];
                if (account.Password == password) return account.Token.ToString();
                else return "Incorrect password";
            }
            else return "Account not found";
        }

    }
}
