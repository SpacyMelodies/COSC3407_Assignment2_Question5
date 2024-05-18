using LinkedListLib;
using System.Threading;
using static System.Random;

/*
 * COSC3407 Assignment 2 Question 5
 *
 *  by Mitchell Plunket
 *  Student ID : 239499150
 *  
 *  program creates 2 threads and uses them to add and remove random integers from a user created linked list data structure
 */
internal class Program
{
    private static void Main(string[] args)
    {
        LinkedListLib.LinkedList linky = new LinkedListLib.LinkedList(); //initializes new created linked list

        // creates and starts a producer and consumer threat to operate on those linked lists
        Thread producer = new Thread(() => AddToLinkedList(linky));
        Thread consumer = new Thread(() => RemoveFromLinkedList(linky));
        producer.Start();
        consumer.Start();
    }

    public static void AddToLinkedList(LinkedList linky)
    {
        // creates a new random number object. runs the code on the thread forever or until user stops execution
        // if the list is full, prints message to the user, else it adds a random number between 1 and 1854 to the
        // linked list, prints a message saying such, then waits 1 second before starting again
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
        // creates a new random number object. runs the code on the thread forever or until user stops execution
        // if the list is empty, prints message to the user, else it removes the number at the end of the
        // linked list, prints a message with the number it removed, and the current size of the linked list
        // then waits 1 second before starting again
        Random rand = new Random();
        while (true)
        {
            if (linky.IsEmpty())
            {
                Console.WriteLine("List was empty");
            }
            else
            {
                int removedNum = linky.Remove();
                if (removedNum == -1)
                {
                    Console.WriteLine("There was an error trying to remove value from linked list");
                }
                Console.WriteLine($"removed {removedNum} from linked list. list now size {linky.Size()}");

            }
            Task.Delay(1000).Wait();
        }
    }
}