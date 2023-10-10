

using Module3HM6_ContactListApp.Validators;
using System.Text.RegularExpressions;

namespace Module3HM6_ContactListApp.Models
{
    internal class Contact
    {
        private string _name;
        private string _surname;
        private string _phone;
        private string _email;

        public string Name 
        {
            get => _name;
            set
            {
                ContactValidator.ValidateName(value);
                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
               ContactValidator.ValidateSurname(value);
                _surname = value;
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {        
                ContactValidator.ValidatePhone(value);
                _phone = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                ContactValidator.ValidateEmail(value);
                _email = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this._name} Surname: {this._surname} Phone: {this._phone} Email: {this._email}";
        }
        

    }
}
