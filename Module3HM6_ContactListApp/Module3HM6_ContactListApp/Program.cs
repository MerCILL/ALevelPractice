using Module3HM6_ContactListApp.Models;

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
    Phone = "+0504028750",
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
    Name = "qqq",
    Surname = "qqq",
    Phone = "+1222334455",
    Email = "qqq@gmail.com"
};

//Console.WriteLine(contact1);
//Console.WriteLine(contact2);
//Console.WriteLine(contact3);
Console.WriteLine(contact4);