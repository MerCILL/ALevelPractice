

using Module3HM6_ContactListApp.Validators;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Module3HM6_ContactListApp.Models
{
    public class Contact
    {
        private string _name;
        private string _surname;
        private string _phone;
        private string _email;

        public Contact(string name, string surname, string phone, string email)
        {
            _name = name;
            _surname = surname;
            _phone = phone;
            _email = email;
        }

        public Contact()
        {

        }

        public string Name 
        {
            get => _name;
            set => _name = ContactValidator.ValidateName(value);
        }

        public string Surname
        {
            get => _surname;
            set => _surname = ContactValidator.ValidateSurname(value);
        }

        public string Phone
        {
            get => _phone;
            set => _phone = ContactValidator.ValidatePhone(value);
        }

        public string Email
        {
            get => _email;
            set => _email = ContactValidator.ValidateEmail(value);  
        }

        public override string ToString()
        {
            return $"Name: {this._name}; Surname: {this._surname}; Phone: {this._phone}; Email: {this._email}";
        }
        

    }
}
