using Linq;
using System.Text.RegularExpressions;

var listInt = new List<int>() {1,1,2,3,4,5,6,6,7,8,9,10,11,12};
var listString = new List<string>() {"Abilities", "forfeited", "situation", "extremely", "my", "to", "he", "resembled", "Old", "had", "conviction", "discretion", "understood", "put", "principles", "you"
};
var str = "Hello, wolrd!";

//1
var resultInt = LinqExercises.FindDivisibleBy_2_3(listInt);
Console.WriteLine("Write a LINQ query to find the numbers in a given array which are divisible by 2 and 3");
foreach (int i in resultInt) Console.WriteLine(i);

//2
Console.WriteLine("Write a LINQ query to find the sum of all the numbers in a given array");
Console.WriteLine(LinqExercises.FindSum(listInt));

//3
Console.WriteLine("Write a LINQ query to find the average of all the numbers in a given array");
Console.WriteLine(LinqExercises.FindAverage(listInt));

//4
Console.WriteLine("Write a LINQ query to find the maximum number in a given array");
Console.WriteLine(LinqExercises.FindMax(listInt));

//4
Console.WriteLine("Write a LINQ query to find the minimum number in a given array");
Console.WriteLine(LinqExercises.FindMin(listInt));

//5
Console.WriteLine("Write a LINQ query to find the numbers greater than 10 in a given array and multiply each number by 10");
resultInt = LinqExercises.FindGreater10Multiply10(listInt);
foreach (int i in resultInt) Console.WriteLine(i);

//6
Console.WriteLine("Write a LINQ query to find the unique characters from a given string");
var resultChars = LinqExercises.FindUniqueCharacters(str);
foreach (var i in resultChars) Console.Write(i + " ");
Console.WriteLine();

//7
Console.WriteLine("Write a LINQ query to find the numbers and the frequency of each number in a given array");
var resultObject = LinqExercises.FindNumbersAndFrequency(listInt);
foreach (var item in resultObject) Console.WriteLine(item);

//8
Console.WriteLine("Write a LINQ query to group the numbers in a given array into even and odd groups and then find the maximum number in each group");
LinqExercises.FindMaximumEvenOdd(listInt);

//9
Console.WriteLine("Find the elements of a list of integers that are greater than the average of the list");
resultInt = LinqExercises.FindGreaterThanAvg(listInt);
foreach (int i in resultInt) Console.WriteLine(i);

//10
Console.WriteLine("Group the elements of a list of strings by the length of the string");
var resultStrings = LinqExercises.GroupByLength(listString);
foreach (var item in resultStrings)
{
    Console.Write($"{item.Length}: ");
    foreach (var i in item.Strings)
    {
        Console.Write($"{i} ");
    }
    Console.WriteLine();
}

Console.WriteLine
    ("Find the elements of a list of strings that contain a given substring, group them by the length " +
    "of the string and project them into a new list with" +
    " the strings in a normalized format (first character upper-case every else lower-case)");
resultStrings = LinqExercises.FindNewListSubstring(listString, "o");
foreach (var item in resultStrings) Console.WriteLine(item);

Console.WriteLine(new string('-', 50));
Console.WriteLine(new string('-', 50));
Console.WriteLine(new string('-', 50));

List<User> users = new List<User>()
{
    new User("FirstName1", "LastName1", "user1@gmail.com", new DateOnly(2000,1,10)),
    new User("FirstName1", "LastName1", "user2@gmail.com", new DateOnly(1990,2,9)),
    new User("First3", "Last3", "user3@gmail.com", new DateOnly(1980,3,8)),
    new User("First4", "Last4", "user4@outlook.com", new DateOnly(2010,4,7)),
    new User("First5", "Last5", "user5@outlook.com", new DateOnly(2010,5,6)),
    new User("First6", "Last6", "user6@outlook.com", new DateOnly(2010,6,5)),
    new User("First7", "Last7", "user7@outlook.com", new DateOnly(2000,7,4)),
    new User("First8", "Last8", "user8@gmail.com", new DateOnly(1995,8,3)),
    new User("First9", "Last9", "user9@gmail.com", new DateOnly(1995,9,2)),
    new User("First10", "Last10", "user10@gmail.com", new DateOnly(2005,10,1)),
};

Console.WriteLine("Find all users whoes age > 18. Produce a projection that produces Full Name, Date of Birth and Current Full Years");
var usersList = LinqExercises.GetUsersOver18(users);
foreach (var item in usersList)
{
    Console.WriteLine(item);
}

Console.WriteLine("Group users by email domain (ex. 'google.com'). Return most used domain and count of userss using that domain.");
var usersListByDomain = LinqExercises.GetUsersByDomain(users);
foreach (var item in usersListByDomain)
{
    Console.WriteLine(item);
}

Console.WriteLine("Convert given collection into optimized for search collection. " +
    "Optimization should be based on User Id. Write a code that searches in that collection by given user Id.");
var user = LinqExercises.FindUserById(users, 1);
Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName} {user.Email} {user.BirthDate}");

Console.WriteLine("Group users by Last Name. Produce groups of 'posible relatives'. " +
    "For each group return optimized for search collection where we search by Last Name, " +
    "and each group is projected into new format: First Name, Possible Relatives, Date of Birh." +
    " Each internal group should be ordered by Date Of Birht. ");

usersList = LinqExercises.GroupUsersByRelatives(users);
Console.WriteLine();
foreach (dynamic item in usersList)
{
    Console.Write($"{item.LastName} ");
    foreach (dynamic item2 in item.Users.Values)
    {
        Console.Write($"{item2.FirstName} {item2.PossibleRelatives} {item2.DateOfBirth} ");
    }
    Console.WriteLine();
}



