using Module4HM1_WebApi.Models;

namespace Module4HM1_WebApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<Dictionary<int,User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<bool> CreateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ChangeCreateUserModel user);
    }
}
