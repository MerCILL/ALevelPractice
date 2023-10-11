using Module3HM6_ContactListApp.Models;


namespace Module3HM6_ContactListApp.Services
{
    public class ContactService
    {
        private readonly SortedSet<Contact> _contacts;
        private readonly ContactTrie _contactTrie;

        public ContactService()
        {
            _contacts = new SortedSet<Contact>(new ContactComparer());
            _contactTrie = new ContactTrie();
        }

        public bool AddContact(Contact contact)
        {
            try
            {
                if (_contacts.Any(x => x.Phone == contact.Phone)) throw new Exception("Contact with this phone already exist");
                if (_contacts.Add(contact)) _contactTrie.Insert(contact.Phone, contact);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding contact error: {ex.Message}");
                return false;
            }
        }

        public bool RemoveContact(string phone)
        {
            //ContactValidator.ValidatePhone(phone);
            try
            {
                if (_contacts.Count == 0) throw new Exception("No contacts have been added.");
                var contact = GetContact(phone);
                if (contact != null)
                {
                    if (_contacts.Remove(contact))
                    {
                        _contactTrie.Remove(contact.Phone);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Removing contact error: {ex.Message}");
            }
            return false;
        }

        public Contact GetContact(string phone)
        {
            try
            {
                if (_contacts.Count == 0) throw new Exception("No one contact has been added");
                if (phone.StartsWith("")) phone = "+" + phone;
                return _contacts.First(x => x.Phone == phone);
            }

            catch (Exception ex) 
            {
                Console.WriteLine($"Getting contact error: {ex.Message}");
                return null;
            }
        }

        public SortedSet<Contact> GetContacts()
        {
            try
            {
                return _contacts;
            }
            catch (Exception)
            {
                Console.WriteLine("Getting contacts error");
                return null;
            }
        }

        public void DisplayContacts()
        {
            try
            {
                foreach (var contact in _contacts)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Displaying contacts error {ex.Message}");
            }
        }

        public void DisplayContacts(SortedSet<Contact> contacts)
        {
            try
            {
                if (contacts == null) throw new ArgumentNullException("Contacts to search is null");
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Displaying contacts error {ex.Message}");
            }
        }

        public SortedSet<Contact> SearchContacts(string prefix)
        {
            try
            {
                return _contactTrie.SearchContacts(prefix);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Searching contacts error {ex.Message}");
                return null;
            }
        }

    }
}
