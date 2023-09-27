using BinaryTreeGenericCollection;

BinaryTree<int> tree = new();
tree.Root = new Node<int>(1);
tree.Root.Left = new Node<int>(2);
tree.Root.Right = new Node<int>(3);
tree.Root.Left.Left = new Node<int>(4);

Console.WriteLine("InOrderTraversal:");
foreach (int key in tree.InOrderTraversal())
{
    Console.Write(key + " ");
}

Console.WriteLine();
Console.WriteLine("Inserted");
tree.Insert(5);

Console.WriteLine("PreOrderTraversal:");
foreach (int key in tree.PreOrderTraversal())
{
    Console.Write(key + " ");
}

tree.Remove(1);
Console.WriteLine();
Console.WriteLine("Removed");
tree.Remove(2);
//tree.Remove(3);


Console.WriteLine("PostOrderTraversal:");
foreach (int key in tree.PostOrderTraversal())
{
    Console.Write(key + " ");
}

Console.WriteLine();
Console.WriteLine("Count: " + tree.Count());



