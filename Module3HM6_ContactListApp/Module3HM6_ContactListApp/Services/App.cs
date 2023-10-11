using Module3HM6_ContactListApp.Models;
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

        public void AddContact()
        {
            try
            {
                Contact contact = new Contact();
                Console.Write("Enter contact name: ");
                contact.Name = Console.ReadLine();
                Console.Write("Enter contact surname(can be empty): ");
                contact.Surname = Console.ReadLine();
                Console.Write("Enter contact phone: ");
                contact.Phone = Console.ReadLine();
                Console.Write("Enter contact email(can be empty): ");
                contact.Email = Console.ReadLine();

                Console.WriteLine();
                bool isAdded = _contactService.AddContact(contact);

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
                bool isRemoved = _contactService.RemoveContact(phone);

                if (isRemoved) Console.WriteLine("Contact was succesfully deleted");
                //else throw new Exception("removing: false");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deleting contact error {ex.Message}");
            }
           
        }

        public void SearchContacts()
        {
            try
            {
                Console.Write("Enter phone to search: ");
                string prefix = Console.ReadLine();

                SortedSet<Contact> contacts = _contactService.SearchContacts(prefix);

                _contactService.DisplayContacts(contacts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while displaying contacts: {ex.Message}");
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

    }
}
