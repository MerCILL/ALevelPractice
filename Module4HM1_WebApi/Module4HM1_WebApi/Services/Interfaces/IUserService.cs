using Module4HM1_WebApi.Models;

namespace Module4HM1_WebApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseListModel> GetUsersAsync(int page);
        Task<User> GetUserAsync(int id);
        Task<bool> CreateAsync(User user);
        Task<bool> CheckEmail(string email);
        Task<bool> DeleteAsync(int id);
        Task<User> UpdateAsync(int id, ChangeCreateUserModel user);
        Task<User> GetUserByEmail(string email);
    }
}
