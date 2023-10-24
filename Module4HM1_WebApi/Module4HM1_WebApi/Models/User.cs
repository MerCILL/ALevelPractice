using System.Text.Json.Serialization;

namespace Module4HM1_WebApi.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private static int _counter = 0;

        [JsonConstructor]
        public User(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public User(string fName, string lName, string email) : this(++_counter, fName, lName, email)
        {
        }

        public static void SetCounter(int counter)
        {
            _counter = counter;
        }

        public static int GetCounter() => _counter;
    }
}
