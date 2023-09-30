using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Linq
{
    public static class LinqExercises
    {
        //Write a LINQ query to find the numbers in a given array which are divisible by 2 and 3
        public static IEnumerable<int> FindDivisibleBy_2_3(IEnumerable<int> ints)
        {
            return ints.Where(x => x % 2 == 0 && x % 3 == 0);
        }

        //Write a LINQ query to find the sum of all the numbers in a given array
        public static int FindSum(IEnumerable<int> ints)
        {
            return ints.Sum();
        }

        //Write a LINQ query to find the average of all the numbers in a given array
        public static double? FindAverage(IEnumerable<int> ints)
        {
            return ints.DefaultIfEmpty().Average();
        }

        //Write a LINQ query to find the maximum number in a given array
        public static int? FindMax(IEnumerable<int> ints)
        {
            return ints.DefaultIfEmpty().Max();
        }

        //Write a LINQ query to find the minimum number in a given array
        public static int? FindMin(IEnumerable<int> ints)
        {
            return ints.DefaultIfEmpty().Min();
        }

        //Write a LINQ query to find the numbers greater than 10 in a given array and multiply each number by 10
        public static IEnumerable<int> FindGreater10Multiply10(IEnumerable<int> ints)
        {
            return ints.Where(x => x > 10).Select(x => x * 10 );
        }

        //Write a LINQ query to find the unique characters from a given string
        public static IEnumerable<char> FindUniqueCharacters(string str)
        {
            return str.Distinct();
        }

        public static IEnumerable<object> FindNumbersAndFrequency(IEnumerable<int> ints)
        {
            return ints.GroupBy(x => x)
                .Select(group => new { Number = group.Key, Frequency = group.Count() });
        }

        public static void FindMaximumEvenOdd(IEnumerable<int> ints)
        {
            var groupEvenOdd = ints.GroupBy(n => n % 2 == 0 ? "Even numbers" : "Odd numbers");
            foreach (var item in groupEvenOdd)
            {
                var aggregatedGroups = item.Aggregate($"{item.Key} ", (current, number) => current + (number + " "));
                Console.WriteLine(aggregatedGroups);
            }

            var maxNumbersInGroup = groupEvenOdd.Select(group => new { Group = group.Key, MaxNumber = group.Max() });
            foreach (var item in maxNumbersInGroup) Console.WriteLine($"Max {item.Group} number: {item.MaxNumber}");
        }
        
        public static IEnumerable<int> FindGreaterThanAvg(IEnumerable<int> ints)
        {
            return ints.Where(x => x > ints.Average());
        }

        public static IEnumerable<dynamic> GroupByLength(IEnumerable<string> strings)
        {
            return strings.GroupBy(s => s.Length)
                  .Select(group => new { Length = group.Key, Strings = group.ToList() });
        }

        public static IEnumerable<string> FindNewListSubstring(IEnumerable<string> strings, string substring)
        {
            return strings.Where(s => s.ToLower().Contains(substring.ToLower()))
                  .GroupBy(s => s.Length)
                  .Select(group => string.Join(", ", group.Select(s => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower()))));
        }

        public static IEnumerable<object> GetUsersOver18(IEnumerable<User> users)
        {
            return users
                .Where(user => (DateTime.Today.Year - user.BirthDate.Year > 18)
                               || (DateTime.Today.Year - user.BirthDate.Year == 18
                                   && DateTime.Today.DayOfYear >= user.BirthDate.DayOfYear))
                .Select(user => new
                {
                    FullName = $"{user.FirstName} {user.LastName}",
                    DateOfBirth = user.BirthDate,
                    Age = DateTime.Today.Year - user.BirthDate.Year
                });
        }

        public static List<(string Domain, int Count)> GetUsersByDomain(IEnumerable<User> users)
        {
            var domainGroups = users
                .GroupBy(user => user.Email.Split('@').Last())
                .Select(group => (Domain: group.Key, Count: group.Count()))
                .OrderByDescending(group => group.Count);

            int maxCount = domainGroups.First().Count;

            return domainGroups
                .Where(group => group.Count == maxCount)
                .ToList();
        }

        public static User FindUserById(IEnumerable<User> users, int id)
        {
            var usersDictionary = users.ToDictionary(user => user.Id, user => user);

            return usersDictionary.TryGetValue(id, out User user) ? user : null;
        }

        public static IEnumerable<dynamic> GroupUsersByRelatives(IEnumerable<User> users)
        {
            return users
                .GroupBy(user => user.LastName)
                .Select(group => new
                {
                    LastName = group.Key,
                    Users = group
                        .OrderBy(user => user.BirthDate)
                        .Select(user => new
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            PossibleRelatives = string.Join(", ", group.Where(u => u.FirstName != user.FirstName).Select(u => u.FirstName)),
                            DateOfBirth = user.BirthDate
                        })
                        .ToDictionary(user => user.Id, user => user)
                });
        }

    }
}
