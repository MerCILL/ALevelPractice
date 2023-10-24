using Module4HM1_WebApi.Models;
using Module4HM1_WebApi.Repositories.Interfaces;
using Module4HM1_WebApi.Services;
namespace Module4HM1_WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static Dictionary<int, User> _usersDict = new();
        public UserRepository()
        {
            var usersList = FileService.ReadFromFileAsync().Result;
            _usersDict = usersList.ToDictionary(user => user.Id, user => user);
        }

        public async Task<User> GetUserAsync(int id)
        {
            //_usersList = await FileService.ReadFromFileAsync();
            if (!_usersDict.ContainsKey(id)) return null;
            return _usersDict[id];
        }

        public async Task<Dictionary<int,User>> GetUsersAsync()
        {
            //_usersList = await FileService.ReadFromFileAsync();
            return _usersDict;
        }

        public async Task<bool> CreateAsync(User user)
        {
            var counterValue = int.Parse(await File.ReadAllTextAsync(FileService.counterPath));
            Console.WriteLine("Count: " + _usersDict.Count);
            Console.WriteLine("Counter: " +  counterValue);
            if (_usersDict.Count != counterValue) User.SetCounter(counterValue + 1);

            var isCreated = _usersDict.TryAdd(user.Id, user);
            if (isCreated)
            {
                await FileService.WriteCounterInFile();
                await FileService.WriteInFileAsync(user);
                return true;
            }
            return false;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (!_usersDict.ContainsKey(id)) return false;

            _usersDict.Remove(id);
            await FileService.DeleteUserFromFile(_usersDict.Values.ToList());

            return true;
        }

        public async Task<bool> UpdateAsync(int id, ChangeCreateUserModel user)
        {
            if(_usersDict.ContainsKey(id) && _usersDict.Any(x => x.Value.Email != user.Email))
            {
                _usersDict[id].FirstName = user.FirstName;
                _usersDict[id].LastName = user.LastName;
                _usersDict[id].Email = user.Email;

                await FileService.UpdateUser(id, user);
                return true;
            }
            return false;
        }

    }
}
