using Module4HM1_WebApi.Models;

namespace Module4HM1_WebApi.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> RegisterAsync(string email, string password);
        Account GetAccount(string email);
        string Login(string email, string password);
    }
}
