namespace Module4HM1_WebApi.Models
{
    public class Account
    {
        public Guid Token { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Account(string email, string password)
        {
            Token = Guid.NewGuid();
            Email = email;
            Password = password;
        }

    }
}
