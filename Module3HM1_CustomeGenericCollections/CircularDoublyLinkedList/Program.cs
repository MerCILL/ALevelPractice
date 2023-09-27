using CircularDoublyLinkedList;

CircularDoubleLinkedList<int> circularDoubleLinkedList = new();

//circularDoubleLinkedList.AddFirst(2);
//circularDoubleLinkedList.AddLast(5);
//circularDoubleLinkedList.AddFirst(3);
//Console.WriteLine(circularDoubleLinkedList.Count);
//Console.WriteLine(circularDoubleLinkedList.First.Value);
//Console.WriteLine(circularDoubleLinkedList.Last.Value);
//Console.WriteLine(circularDoubleLinkedList[2]);

circularDoubleLinkedList.AddFirst(1);
circularDoubleLinkedList.AddLast(2);
circularDoubleLinkedList.AddAfter(circularDoubleLinkedList[0], 10);
circularDoubleLinkedList.AddBefore(circularDoubleLinkedList[1], 20);


foreach (var item in circularDoubleLinkedList)
{
    Console.WriteLine(item);
}

circularDoubleLinkedList.RemoveFirst();
circularDoubleLinkedList.RemoveLast();

int[] arr = new int[3];
circularDoubleLinkedList.CopyTo(arr, 2);

Console.WriteLine(arr.Contains(10));

foreach (var item in circularDoubleLinkedList)
{
    Console.WriteLine(item);
}
