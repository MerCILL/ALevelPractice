using Extensions;

List<int> list = new() { 1, 2, 3 };

Console.WriteLine(list.FirstOrDefault2(x => x > 1));

var newList = list.SkipWhile2(x => x < 2);
foreach (var item in newList) Console.WriteLine(item);