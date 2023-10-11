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
//await contactService.AddContactAsync(contact1);
//await contactService.AddContactAsync(contact2);
//await contactService.AddContactAsync(contact3);
//await contactService.AddContactAsync(contact4);
//await contactService.RemoveContactAsync("+380665351626");
//contactService.DisplayContacts();

App app = new(contactService);
app.ClearFile();
app.AddContact();
app.AddContact();
//app.RemoveContact();
app.DisplayContacts();
Console.WriteLine();
app.SearchContactsByPrefix();

