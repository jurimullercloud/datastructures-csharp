// See https://aka.ms/new-console-template for more information
using DataStructures.Implementation;


var arr = new DynamicArray<int>();

Console.WriteLine(arr);
arr.Add(4);
arr.Add(5);
arr.Add(-1);
Console.WriteLine(arr);

arr.Insert(2, 12);
Console.WriteLine(arr);