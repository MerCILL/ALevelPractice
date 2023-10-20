using Module3HM6_ContactListApp.Models;
using Module3HM6_ContactListApp.Validators;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HM6_ContactListApp.Services
{
    public class App
    {
        private readonly ContactService _contactService;
        private FileSystemWatcher _watcher;
        public App(ContactService contactService)
        {
            _contactService = contactService;
            InitializeWatcher();
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine(":store: to add contact");
                Console.WriteLine(":read: to display contacts");
                Console.WriteLine(":remove: to remove contact");
                Console.WriteLine(":search: to find contacts by prefix");
                Console.WriteLine(":exit: to close program");
                Console.WriteLine("");
                string option = Console.ReadLine();
                option = option.ToLower();

                switch (option)
                {
                    case "store":                      
                    case "remove":
                        using (var mutex = new Mutex(false, "WriteToFile"))
                        {
                            mutex.WaitOne();
                            try
                            {
                                switch (option)
                                {
                                    case "store":
                                        AddContact();
                                        break;
                                    case "remove":
                                        RemoveContact();
                                        break;
                                }
                            }
                            finally
                            {
                                mutex.ReleaseMutex();
                            }                         
                        }
                        break;
                    case "read":
                        DisplayContacts();
                        Console.WriteLine();
                        break;
                    case "search":
                        SearchContactsByPrefix();
                        Console.WriteLine();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        Console.WriteLine();
                        break;
                }
            }
        }

        public void InitializeWatcher()
        {
            try
            {


                var filePath = _contactService.GetFilePath();
                _watcher = new FileSystemWatcher
                {
                    Path = Path.GetDirectoryName(filePath),
                    Filter = Path.GetFileName(filePath)
                };

                _watcher.Changed += OnChanged;
                _watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Monitor initialization error: {ex.Message}");
            }
        }
  
        private void AddContact()
        {
            try
            {
                Contact contact = new Contact();
                Console.Write("Enter contact name: ");
                contact.Name = Console.ReadLine();
                contact.Name = ContactValidator.ValidateName(contact.Name);
                Console.Write("Enter contact surname(can be empty): ");
                contact.Surname = Console.ReadLine();
                contact.Surname = ContactValidator.ValidateSurname(contact.Surname);
                Console.Write("Enter contact phone: ");
                contact.Phone = Console.ReadLine();
                contact.Phone = ContactValidator.ValidatePhone(contact.Phone);
                Console.Write("Enter contact email(can be empty): ");
                contact.Email = Console.ReadLine();
                contact.Email = ContactValidator.ValidateEmail(contact.Email);

                Console.WriteLine();
                bool isAdded = _contactService.AddContactAsync(contact).Result;
                if (isAdded) Console.WriteLine("Contact was succesfully added");
                //else throw new Exception("adding: false");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Adding contact error: {ex.Message}");
            }
        }

        private void RemoveContact()
        {
            try
            {
                Console.WriteLine("Enter phone to delete contact");
                string phone = Console.ReadLine();
                phone = ContactValidator.ValidatePhone(phone);
                bool isRemoved = _contactService.RemoveContactAsync(phone).Result;

                if (isRemoved) Console.WriteLine("Contact was succesfully deleted");
                //else throw new Exception("removing: false");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deleting contact error {ex.Message}");
            }
        }

        private void ClearFile()
        {
            try { _contactService.ClearFile(); }
            catch (Exception ex)
            {
                Console.WriteLine($"Clearing file content error: {ex.Message}");
            }
        }
       
        private void DisplayContacts()
        {
            try
            {
                _contactService.DisplayContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Display contacts error: {ex.Message}");
            }
        }

        private void SearchContactsByPrefix()
        {
            try
            {

                var searchResult = new ConcurrentDictionary<string, Contact>();

                Console.WriteLine("Enter prefix to search: ");
                string prefix = Console.ReadLine();

                searchResult = _contactService.SearchContactsByPrefix(prefix);
                _contactService.DisplayContacts(searchResult);
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Searching contact error: {ex.Message}");
            }

        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine($"File changed: {e.FullPath} {e.ChangeType}");
        }


    }
}
