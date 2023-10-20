using Module3HM6_ContactListApp.Models;
using Module3HM6_ContactListApp.Validators;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Module3HM6_ContactListApp.Services
{
    public class ContactService
    {
        private ConcurrentDictionary<string, Contact> _contacts;
        private readonly ContactTrie _contactTrie;
        private readonly string _filePath;

        private ContactService()
        {
            _contacts = new ConcurrentDictionary<string, Contact>();
            _contactTrie = new ContactTrie();
            _filePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../Contact.txt"));
        }

        public static async Task<ContactService> CreateAsync()
        {
            var contactService = new ContactService();
            await contactService.ReadFromFileAsync();
            return contactService;
        }

        public async Task<bool> AddContactAsync(Contact contact)
        {
            if (_contacts.ContainsKey(contact.Phone)) throw new Exception("This contact already exist");

            _contacts.TryAdd(contact.Phone, contact);
            _contactTrie.Insert(contact.Phone, contact);

            string json = JsonSerializer.Serialize(contact);
            using (var streamWriter = new StreamWriter(_filePath, true))
                await streamWriter.WriteLineAsync(json);

            return true;
        }

        public async Task<bool> RemoveContactAsync(string phone)
        {
            ContactValidator.ValidatePhone(phone);
            if (!_contacts.ContainsKey(phone))
                throw new Exception("No contact with this phone exists.");

            _contacts.TryRemove(phone, out _);
            _contactTrie.Remove(phone);

            if (_contacts.Count > 0)
            {
                string json = JsonSerializer.Serialize(_contacts.Values);
                await File.WriteAllTextAsync(_filePath, json);
            }
            else await File.WriteAllTextAsync(_filePath, string.Empty);

            return true;
        }

        public void CheckFileExist()
        {
            if (!File.Exists(_filePath))
                File.Create(_filePath).Dispose();
        }

        public async Task ReadFromFileAsync()
        {
            CheckFileExist();

            var contactLines = await File.ReadAllLinesAsync(_filePath);

            _contacts.Clear();

            foreach (var contactLine in contactLines)
            {
                if (!string.IsNullOrWhiteSpace(contactLine))
                {
                    try
                    {
                        var contact = JsonSerializer.Deserialize<Contact>(contactLine);
                        _contacts.TryAdd(contact.Phone, contact);
                    }
                    catch (JsonException ex)
                    {
                        throw new Exception($"Failed to deserialize line: ({contactLine})... Error: {ex.Message}");
                    }
                }
            }
        }
        public void DisplayContacts()
        {
            foreach (var contact in _contacts.Values)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void DisplayContacts(ConcurrentDictionary<string, Contact> contacts)
        {
            foreach (var contact in contacts)
                Console.WriteLine(contact.Value.ToString());
        }

        public async void ClearFile()
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open)) fs.SetLength(0);
        }

        public ConcurrentDictionary<string, Contact> SearchContactsByPrefix(string prefix) => _contactTrie.SearchContacts(prefix);

        public string GetFilePath() => _filePath;

    }
}
