using Module3HM6_ContactListApp.Models;
using Module3HM6_ContactListApp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3HM6_ContactListApp.Services
{
    public class App
    {
        private readonly ContactService _contactService;
        public App(ContactService contactService)
        {
            _contactService = contactService;
        }

        public void Run()
        {
            string command;
            do
            {
                Console.WriteLine("enter :\"add\": to add contact");
                Console.WriteLine("enter :\"store\": to add contacts to file");
                Console.WriteLine("enter :\"read\": to read all contacts from file");
                Console.WriteLine("enter :\"remove\": to remove contact");
                Console.WriteLine("enter :\"remove\": to remove contact from file");
                Console.WriteLine("enter :\"exit\": to stop app");
                command = Console.ReadLine();
            } while (command != "exit");
        }

        public void AddContact()
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

        public void RemoveContact()
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

        public void ClearFile()
        {
            try { _contactService.ClearFile(); }
            catch (Exception ex)
            {
                Console.WriteLine($"Clearing file content error: {ex.Message}");
            }
        }
       
        public void DisplayContacts()
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

        public void SearchContactsByPrefix()
        {
            try
            {

                var searchResult = new Dictionary<string, Contact>();

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

    }
}
