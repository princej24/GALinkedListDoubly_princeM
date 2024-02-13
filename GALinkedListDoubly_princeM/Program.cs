using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALinkedListDoubly_princeM
{


    class Program
    {
        static void Main(string[] args)
        {
        
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

        
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            Console.WriteLine("Displaying elements from head to tail:");
            list.DisplayForward();

            Console.WriteLine("Displaying elements from tail to head:");
            list.DisplayBackward();

            list.InsertAtIndex(2, 99);
            Console.WriteLine("After inserting 99 at index 2 (before tail):");
            list.DisplayForward();

            list.InsertAtFront(0);
            Console.WriteLine("After inserting 0 at the front (head):");
            list.DisplayForward();

            list.InsertAtEnd(5);
            Console.WriteLine("After inserting 5 at the end (tail):");
            list.DisplayForward();

            
            list.Remove(2);
            Console.WriteLine("After removing element 2:");
            list.DisplayForward();

          
            list.RemoveAtEnd();
            Console.WriteLine("After removing last element (tail):");
            list.DisplayForward();

            list.Clear();
            Console.WriteLine("After clearing the list:");
            list.DisplayForward();
        }
    }
}
