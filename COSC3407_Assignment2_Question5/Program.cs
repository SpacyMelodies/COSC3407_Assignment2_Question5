using LinkedListLib;
using System.Threading;
using static System.Random;
internal class Program
{
    private static void Main(string[] args)
    {
        LinkedListLib.LinkedList linky = new LinkedListLib.LinkedList();

        Thread producer = new Thread(() => AddToLinkedList(linky));
        Thread consumer = new Thread(() => RemoveFromLinkedList(linky));
        producer.Start();
        consumer.Start();
    }

    public static void AddToLinkedList(LinkedList linky)
    {
        Random rnd = new Random();
        while (true)
        {
            if (linky.IsFull())
            {
                Console.WriteLine("List was full");
            }
            else
            {
                int addNum = rnd.Next(1, 1954);
                if (linky.Add(addNum))
                {
                    Console.WriteLine($"Producer thread added {addNum} to the linked list");
                }

            }
            Task.Delay(1000).Wait();
        }
    }

    public static void RemoveFromLinkedList(LinkedList linky)
    {
        Random rand = new Random();
        while (true)
        {
            if (linky.IsEmpty())
            {
                Console.WriteLine("List was empty");
            }
            else
            {
                int removeIndex = rand.Next(0, linky.Size());

                int removedNum = linky.FindAndRemove(removeIndex);
                Console.WriteLine($"removed {removedNum} at index {removeIndex}");

            }
            Task.Delay(1000).Wait();
        }
    }
}