using Module3HM6_ContactListApp.Models;


namespace Module3HM6_ContactListApp.Services
{
    public class ContactComparer : IComparer<Contact>
    {
        int IComparer<Contact>.Compare(Contact? x, Contact? y)
        {
            try
            {
                int result = x?.Name.CompareTo(y?.Name) ?? -1;
                if (result != 0) return result;

                result = x?.Surname.CompareTo(y?.Surname) ?? -1;
                if (result != 0) return result;

                result = x?.Phone.CompareTo(y?.Phone) ?? -1;
                if (result != 0) return result;

                return x?.Email.CompareTo(y?.Email) ?? -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ContactComparer error: {ex.Message}");
                return 0;
            }
        }

    }
}
