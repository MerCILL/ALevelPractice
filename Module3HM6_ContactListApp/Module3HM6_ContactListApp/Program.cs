using Module3HM6_ContactListApp.Models;
using Module3HM6_ContactListApp.Services;

var contact1 = new Contact
{
    Name = "John",
    Surname = "Doe",
    Phone = "+380501112233",
    Email = "john.doe@example.com"
};

var contact2 = new Contact
{
    Name = "Jane",
    Surname = "Doe",
    Phone = "+0504028751",
    Email = "jane.doe@example.net"
};

var contact3 = new Contact
{
    Name = "Test",
    Surname = "User",
    Phone = "+1222334455",
    Email = "test.user@example.com"
};

var contact4 = new Contact()
{
    Name = "zqq",
    Surname = "qqq",
    Phone = "+380665351626",
    Email = "qqq@gmail.com"
};


ContactService contactService = new ContactService();
contactService.AddContact(contact1);
contactService.AddContact(contact2);
contactService.AddContact(contact3);
contactService.AddContact(contact4);
App app = new(contactService);
//app.AddContact();
//app.AddContact();
app.DisplayContacts();
app.SearchContacts();
app.RemoveContact();
app.DisplayContacts();
app.SearchContacts();
//app.DisplayContacts();