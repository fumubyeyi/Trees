using Tree.lib;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

BST tree = new BST();
int[] arr = new int[] { 1, 2, 5, 3, 6, 4 };

foreach(var num in arr)
    tree.Insert(num);

tree.Print("Pre");
Console.WriteLine();
tree.Print("In");
Console.WriteLine();
tree.Print("Post");
Console.WriteLine();
