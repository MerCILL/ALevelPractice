using System.Globalization;

string? userInputCase;
string? userInputItem;
int itemsCountIndex = 0;
string[] items = new string[3];

string[] itemsDate = new string[3];
string[]? itemsStatus = new string[3];
string? userInputStatus;
int indexToSetStatusAndDate;
string? userInputDate;
DateTime statusDate;

do
{
    Console.WriteLine(new string('-', 25));
    Console.WriteLine("| Input one of commands: |");//Commands for user
    Console.WriteLine("| add-item               |");
    Console.WriteLine("| remove-item // *       |");
    Console.WriteLine("| mark-as                |");
    Console.WriteLine("| show                   |");
    Console.WriteLine("| exit                   |");
    Console.WriteLine(new string('-', 25));
    userInputCase = Console.ReadLine();
    userInputCase = userInputCase?.ToLower();

    switch (userInputCase)
    {
        case "add-item":

            Console.WriteLine("Enter item to add:");
            userInputItem = Console.ReadLine();

            if (String.IsNullOrEmpty(userInputItem) || CheckExistingItem(items, userInputItem) == false)//Validation/Check existing item
            {
                Console.WriteLine("Incorrect/Existing item");
                break;
            }
            else
            {
                AddItemsFreeSpace(ref items, ref itemsStatus, ref itemsDate);//Checking/Adding free space in items array
                items[itemsCountIndex] = userInputItem;
                itemsCountIndex++;
                Console.WriteLine("Succesfully added item");
                break;
            }

        case "remove-item":

            Console.WriteLine("Input item to delete:");
            userInputItem = Console.ReadLine();
            //userInputItem = userInputItem.ToLower();
            if (!string.IsNullOrEmpty(FindItem(items, userInputItem)))//Checking for an existing item in items array
            {
                DeleteItem(ref items, ref itemsStatus, ref itemsDate, userInputItem);//Deleting item from array
                Console.WriteLine("Item was succesfully deleted");
                itemsCountIndex--;
                break;
            }

            break;

        case "*":
            DeleteAllItems(ref items, ref itemsStatus, ref itemsDate);//Deleting all items from array
            itemsCountIndex = 0;
            Console.WriteLine("All items were deleted");
            break;

        case "mark-as":
            Console.WriteLine("Input user item to mark-as");//Checking for an existing item in items array.
            userInputItem = Console.ReadLine();
            //userInputItem = userInputItem.ToLower();
            if (FindItem(items, userInputItem) == null)
            {
                Console.WriteLine("Item doesn't exist");
                break;
            }
            else
            {
                Console.WriteLine("Input item status");
                userInputStatus = Console.ReadLine();
                if (userInputStatus != "0" && userInputStatus != "1")//Status input validation
                {
                    Console.WriteLine("Incorrect status");
                    break;
                }
                else
                {
                    indexToSetStatusAndDate = FindItemIndex(items, userInputItem);//Finding index of "mark-as" item
                    //int.TryParse(userInputStatus, out itemsStatus[indexToSetStatus]);
                    if (userInputStatus == "1")
                    {
                        Console.WriteLine("Input item complete date: dd.MM.yyyy HH:mm:ss:");
                        userInputDate = Console.ReadLine();

                        //Parsing date with format dd.MM.yyyy HH:mm:ss
                        if (DateTime.TryParseExact(userInputDate, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out statusDate))
                        {
                            //Adding status and date
                            itemsStatus[indexToSetStatusAndDate] = Convert.ToString(userInputStatus);
                            itemsDate[indexToSetStatusAndDate] = userInputDate.ToString();

                             Console.WriteLine("Status and date were added");
                        }

                        else if(string.IsNullOrWhiteSpace(userInputDate))
                        {
                            //Setting current date if user didn't input it
                            itemsStatus[indexToSetStatusAndDate] = Convert.ToString(userInputStatus);
                            itemsDate[indexToSetStatusAndDate] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                            Console.WriteLine("Status and date were added");
                        }

                        else
                        {
                            Console.WriteLine("Date setting error");
                            break;
                        }
                    }
                    //Deleting date if user changes status from 1 to 0
                    else
                    {
                        if (itemsDate[indexToSetStatusAndDate] != null)
                            itemsDate[indexToSetStatusAndDate] = null;
                        itemsStatus[indexToSetStatusAndDate] = Convert.ToString(userInputStatus);
                    }

                }
            }
            break;

        case "show"://Show items
            Console.WriteLine("Input \"1\" or \"0\" or press enter to see items");
            userInputStatus = Console.ReadLine();
            if (userInputStatus == "1" || userInputStatus == "0" || userInputStatus == "")
            {
                ShowItems(items, itemsStatus, itemsDate, userInputStatus);
                break;
            }
            else
            {
                Console.WriteLine("User input error");
                break;
            }

  }
} while (userInputCase != "exit");



void ShowItems(string[] items, string[] statusItems, string[] itemsDate, string itemStatus)
{
    int i;
    if (itemStatus == "1")
    {
        for (i = 0; i < items.Length; i++)
        {
            if (items[i] != null && itemsStatus[i] == "1")
            {
                Console.Write($"Item #{i + 1}: {items[i]};");
                Console.Write($" Status: Completed; Complete date: {itemsDate[i]}");
                Console.WriteLine();
            }
        }
    }

    else if(itemStatus == "0")
    {
        for (i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (items[i] != null && itemsStatus[i] == "0")
                {
                    Console.Write($"Item #{i + 1}: {items[i]};");
                    Console.Write($" Status: Not completed;");
                    Console.WriteLine();
                }
            }
        }
    }

    else if(itemStatus == "")
    {
        for (i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                Console.Write($"Item #{i + 1}: {items[i]};");
                if (itemsStatus[i] != null)
                {
                    if (itemsStatus[i] == "1")
                        Console.Write($" Status: Completed; Complete date: {itemsDate[i]}");
                    else
                        Console.Write($" Status: Not completed;");
                }
                Console.WriteLine();
            }
        }
    }

}

string FindItem(string[] items, string? itemToFind)
{
    foreach (var item in items)
    {
        if (item == itemToFind)
            return itemToFind;
    }
    return null;
}

int FindItemIndex(string[] items, string itemToFind)
{
    for (int i = 0; i < items.Length; i++)
    {
        if (items[i] == itemToFind) return i;
    }

    return -1;
}

void DeleteItem(ref string[] items, ref string[] itemsStatus, ref string[] itemsDate, string itemToDelete)
{
    int indexToDelete = FindItemIndex(items, itemToDelete);

    for (int i = indexToDelete; i < items.Length - 1; i++)
    {
        items[i] = items[i + 1];
        itemsStatus[i] = itemsStatus[i + 1];
        itemsDate[i] = itemsDate[i + 1];
    }

    Array.Clear(items, items.Length - 1, 1);

}

bool CheckItemsFreeSpace(string[] items, int itemsCountIndex)
{
    return itemsCountIndex < items.Length;
}

void AddItemsFreeSpace(ref string[] items, ref string[] itemsStatus, ref string[] itemsDate)
{
    if (!CheckItemsFreeSpace(items, itemsCountIndex))
    {
        Array.Resize(ref items, items.Length * 2);
        Array.Resize(ref itemsStatus, itemsStatus.Length * 2);
        Array.Resize(ref itemsDate, itemsDate.Length * 2);
    }

}

bool CheckExistingItem(string[] items, string itemToCheck)
{
    foreach (var item in items)
    {
        if (item != null && item.ToLower() == itemToCheck.ToLower())
            return false;
    }
    return true;
}

void DeleteAllItems(ref string[] items, ref string[] itemsStatus, ref string[] itemsDate)
{
    Array.Clear(items, 0, items.Length);
    Array.Resize(ref items, 10);

    Array.Clear(itemsStatus, 0, itemsStatus.Length);
    Array.Resize(ref itemsStatus, 10);

    Array.Clear(itemsDate, 0, itemsDate.Length);
    Array.Resize(ref itemsDate, 10);
}