using DoublyLinkedList;

var customLinkedList = new CustomLinkedList<int>();

for (var i = 0; i < 10; i++)
{
    customLinkedList.Add(i);
}

foreach (var i in customLinkedList)
{
    Console.WriteLine(i);
}

Console.ReadKey();