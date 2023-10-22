using Module4HM1_WebApi.Models;
using System.Text.Json;

namespace Module4HM1_WebApi.Services
{
    public static class FileService
    {
        public static string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Users.txt");
        public static string counterPath = Path.Combine(Directory.GetCurrentDirectory(), "Counter.txt");
        public static async Task WriteInitializeUsers()
        {
            CheckFileCreate();
        
            var users = new List<User>();
            users.Add(new User("George", "Bluth", "george.bluth@reqres.in"));
            users.Add(new User("Janet", "Weaver", "janet.weaver@reqres.in"));
            users.Add(new User("Emma", "Wong", "emma.wong@reqres.in"));
            users.Add(new User("Eve", "Holt", "eve.holt@reqres.in"));
            users.Add(new User("Charles", "Morris", "charles.morris@reqres.in"));
            users.Add(new User("Tracey", "Ramos", "tracey.ramos@reqres.in"));
            users.Add(new User("Michael", "Lawson", "michael.lawson@reqres.in"));
            users.Add(new User("Lindsay", "Ferguson", "lindsay.ferguson@reqres.in"));
            users.Add(new User("Tobias", "Funke", "tobias.funke@reqres.in"));
            users.Add(new User("Byron", "Fields", "byron.fields@reqres.in"));
            users.Add(new User("George", "Edwards", "george.edwards@reqres.in"));
            users.Add(new User("Rachel", "Howell", "rachel.howell@reqres.in"));

            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(users, jsonOptions);
            await File.WriteAllTextAsync(filePath, json);

            await File.WriteAllTextAsync(counterPath, User.GetCounter().ToString());
        }

        public static async Task WriteInFileAsync(User user)
        {
            var users = await ReadFromFileAsync();
            users.Add(user);

            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(users, jsonOptions);
            await File.WriteAllTextAsync(filePath, json);

        }

        public static async Task WriteCounterInFile()
        {
            await File.WriteAllTextAsync(counterPath, User.GetCounter().ToString());
        }

        public static async Task<List<User>> ReadFromFileAsync()
        {
            var jsonFromFile = await File.ReadAllTextAsync(filePath);
            var usersFromFile = JsonSerializer.Deserialize<List<User>>(jsonFromFile);

            if (File.Exists(counterPath))
            {
                var counterValue = int.Parse(await File.ReadAllTextAsync(counterPath));
                User.SetCounter(counterValue);
            }

            return usersFromFile;
        }

        public static async Task<bool> DeleteUserFromFile(List<User> users)
        {
            var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(users, jsonOptions);
            await File.WriteAllTextAsync(filePath, json);

            var counterValue = int.Parse(await File.ReadAllTextAsync(counterPath));
            User.SetCounter(counterValue - 1);
            await File.WriteAllTextAsync(counterPath, User.GetCounter().ToString());
            return true;

        }

        public static async Task<bool> UpdateUser(int id, ChangeCreateUserModel user)
        {
                var users = await FileService.ReadFromFileAsync();
                users[id - 1].FirstName = user.FirstName;
                users[id - 1].LastName = user.LastName;
                users[id - 1].Email = user.Email;

                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(users, jsonOptions);
                await File.WriteAllTextAsync(filePath,json);
                return true;
        }

        public static void CheckFileCreate()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            if (!File.Exists(counterPath))
                File.Create(counterPath).Dispose();
        }


    }
}
