using SearchingSortingRecursion;

List<int> list = new() { 1, 5, 7, 10, 15, 20 };
Console.WriteLine(list.BinarySearch<int>(5));



Console.WriteLine(Recursion.Fibonacci(10));
Console.WriteLine(Recursion.Factorial(5));

var dictionary = new Dictionary<int, string>
{
    { 1, "one" },
    { 2, "two" },
    { 3, "three" },
    { 4, "four" },
    { 5, "five" }
};


var sortedKeys = dictionary.Keys.QuickSort();
foreach (var item in sortedKeys.Reverse())
{
    Console.WriteLine(item);
}