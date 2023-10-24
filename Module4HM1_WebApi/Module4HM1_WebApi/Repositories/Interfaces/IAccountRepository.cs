using Module4HM1_WebApi.Models;

namespace Module4HM1_WebApi.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> RegisterAsync(string email, string password);
        Account GetAccount(string email);
        string Login(string email, string password);
    }
}
