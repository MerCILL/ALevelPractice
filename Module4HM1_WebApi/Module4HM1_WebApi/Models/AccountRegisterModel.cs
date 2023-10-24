namespace Module4HM1_WebApi.Models
{
    public class AccountRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountRegisterModel(string email, string password)
        {
            Email = email;
            Password = password;
        }   
    }
}
