using ListBinarySearch;

List<int> list = new() { 5, 10, 15, 20 };
int itemIndex = list[list.BinarySearch(10)];
Console.WriteLine(itemIndex);