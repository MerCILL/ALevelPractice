using Module3HM6_ContactListApp.Models;
using Module3HM6_ContactListApp.Validators;
using System.IO;

namespace Module3HM6_ContactListApp.Services
{
    public class ContactService
    {
        private readonly Dictionary<string, Contact> _contacts;
        private readonly ContactTrie _contactTrie;
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Contact.txt");

        public ContactService()
        {
            _contacts = new Dictionary<string, Contact>();
            _contactTrie = new ContactTrie();
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            try
            {
                if (!_contacts.ContainsKey(contact.Phone))
                {
                    await ReadFromFileAsync();
                    if (_contacts.ContainsKey(contact.Phone))
                        throw new Exception("Contact with this phone already exists.");
                }
           
                _contacts[contact.Phone] = contact;
                _contactTrie.Insert(contact.Phone, contact);

                using (StreamWriter sw = new(_filePath, true))
                    await sw.WriteLineAsync(contact.ToString());
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding contact error: {ex.Message}");
                return false; ;
            }
        }

        public async Task<bool> RemoveContactAsync(string phone)
        {
            try
            {
                ContactValidator.ValidatePhone(phone);
                if (!_contacts.ContainsKey(phone))
                    throw new Exception("No contact with this phone exists.");

                _contacts.Remove(phone);
                _contactTrie.Remove(phone);

                using (StreamWriter writer = new StreamWriter(_filePath, false))
                {
                    foreach (var contact in _contacts.Values)
                        await writer.WriteLineAsync(contact.ToString());
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Removing contact error: {ex.Message}");
                return false;
            }
        }

        public void CheckFileExist()
        { 
            if (!File.Exists(_filePath))
                File.Create(_filePath).Dispose();
        }

        public async Task ReadFromFileAsync()
        {
            if (!File.Exists(_filePath)) throw new FileNotFoundException("No one contact has been added");

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(';');

                    Contact contact = new()
                    {
                        Name = parts[0].Split(':')[1].Trim(),
                        Surname = parts[1].Split(':')[1].Trim(),
                        Phone = parts[2].Split(':')[1].Trim(),
                        Email = parts[3].Split(':')[1].Trim(),
                    };

                    if (!_contacts.ContainsKey(contact.Phone))
                    {
                        _contacts[contact.Phone] = contact;
                        _contactTrie.Insert(contact.Phone, contact);
                    }
                }
            }
        }

        public async void DisplayContacts()
        {
            await ReadFromFileAsync();
            foreach (var contact in _contacts)
                Console.WriteLine(contact.Value.ToString());
        }

        public void DisplayContacts(Dictionary<string, Contact> contacts)
        {
            foreach (var contact in contacts)
                Console.WriteLine(contact.Value.ToString());
        }

        public async void ClearFile()
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open)) fs.SetLength(0);
        }

        public Dictionary<string, Contact> SearchContactsByPrefix(string prefix)
        {
            try
            {
                return _contactTrie.SearchContacts(prefix);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Searching contacts error: {ex.Message}");
                return null;
            }
        }

    }
}
