using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Module4HM1_WebApi.Models;
using Module4HM1_WebApi.Repositories.Interfaces;
using Module4HM1_WebApi.Services.Interfaces;

namespace Module4HM1_WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseListModel> GetUsersAsync(int page)
        {
            var users = await _userRepository.GetUsersAsync();
            int perPage = 6;
            var usersPerPage = users.Values.Skip((page - 1) * perPage).Take(perPage).ToList();
            var totalUsers = users.Count;
            var totalPages = totalUsers / perPage;

            return new UserResponseListModel
            {
                Page = page,
                PerPage = perPage,
                Total = totalUsers,
                TotalPages = totalPages,
                Data = usersPerPage
            };
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public async Task<bool> CreateAsync(User user)
        {
           return await _userRepository.CreateAsync(user);
        }

        public async Task<bool> CheckEmail(string email)
        {
            var users = await _userRepository.GetUsersAsync();
            if (users.Any(x => x.Value.Email == email)) return true;
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<User> UpdateAsync(int id, ChangeCreateUserModel user)
        {
            var isUpdated = await _userRepository.UpdateAsync(id, user);
            if (!isUpdated) return null;

            var users = await _userRepository.GetUsersAsync();
            return users[id];
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var users = await _userRepository.GetUsersAsync();
            return users.FirstOrDefault(x => x.Value.Email == email).Value;
        }

    }
}
