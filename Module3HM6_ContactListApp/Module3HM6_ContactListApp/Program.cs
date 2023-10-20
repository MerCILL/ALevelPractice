using Module3HM6_ContactListApp.Services;

ContactService contactService = await ContactService.CreateAsync();
App app = new(contactService);
app.Run();

