

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
                if(string.IsNullOrEmpty(value)) throw new ArgumentException("Name can't be empty");
                if (value.Length > 25) throw new ArgumentException("Name length can't be longer than 25 characters");
                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name can't be empty");
                if (value.Length > 25) throw new ArgumentException("Name length can't be longer than 25 characters");
                _surname = value;
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Phone number can't be empty");
                if (value.Length < 10 || value.Length > 15) throw new ArgumentException("Phone number length must be between 10 and 15 characters");
                if (!Regex.IsMatch(value, @"^\+?\d+$")) throw new ArgumentException("Phone number must contain only digits or + and digits");

                if (value.StartsWith("0")) value = "+38" + value; //0504028751 ---> +380504028751
                if (value.StartsWith("+0")) value = "+380" + value.Substring(2);//+0504028751 ---> +380504028751
                if (!value.StartsWith("+")) value = "+" + value;//12223334455 ---> +12223334455

                var countryCode1 = int.Parse(value.Substring(1, 1)); 
                var countryCode2 = int.Parse(value.Substring(1, 2));
                var countryCode3 = int.Parse(value.Substring(1, 3));

                bool isValidCountryCode1 = Enum.IsDefined(typeof(CountryCode), countryCode1);
                bool isValidCountryCode2 = Enum.IsDefined(typeof(CountryCode), countryCode2);
                bool isValidCountryCode3 = Enum.IsDefined(typeof(CountryCode), countryCode3);

                if (!isValidCountryCode1 && !isValidCountryCode2 && !isValidCountryCode3) throw new ArgumentException("Invalid country code");

                int startSubstringPosition = isValidCountryCode1 ? 2 : isValidCountryCode2 ? 3 : 4;

                var uniqueLeftPhoneNumber = value.Substring(startSubstringPosition);
                if (!Regex.IsMatch(uniqueLeftPhoneNumber, @"^\d{9,10}$")) throw new ArgumentException("Phone must contain 10 digits after code");

                _phone = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (!Regex.IsMatch(value, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$")) throw new ArgumentException("Email validation error");
                _email = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this._name} Surname: {this._surname} Phone: {this._phone} Email: {this._email}";
        }
        

    }
}
