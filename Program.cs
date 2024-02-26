using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_EdnaLynnLaxa
{//Edna Lynn Laxa 
 //Programming V 
 //Assignment: Data Structure Midterm 
 //February 22, 2024 
    internal class Program
    {
        static void Main(string[] args)
        {
            SinglyListFunctions(); 
            DoublyLinkedFunction();
            QueueFunctions();
            StackonStack(); 
            
        }
        public static void SinglyListFunctions()
        {
            //Singly Linked List 
            Console.WriteLine("Singly Linked List Functions");
            Console.WriteLine("*****************************");
            SinglyLinkedList<string> singerList = new SinglyLinkedList<string>();
             //Producing a list of singers 
            singerList.Add("Selena Gomez");// FUNCTION WORKS 
            singerList.Add("William Singe");
            singerList.Add("Justin Bieber");
            singerList.Add("Tyneisha Keli");
            singerList.Add("Paula DeAnda");
            singerList.Display(); // Displaying

            Console.WriteLine();// Spacing 

            Console.WriteLine("Task 1: Insert Drake @ Index 4");
            Console.WriteLine("********");
            singerList.InsertAtIndex("Drake", 4); // FUNCTION WORKS 
            singerList.Display();

            Console.WriteLine();// Spacing 

            Console.WriteLine("Task 2: Remove Index 4, which will remove Drake");
            singerList.RemoveAt(4);// FUNCTION WORKS 
            singerList.Display();

            Console.WriteLine(); //Spacing 

            Console.WriteLine("Task 3: Remove Artist by name entry: Justin Bieber");
            singerList.Remove("Justin Bieber");// Removing artist Justin Bieber ' // FUNCTION WORKS 
            singerList.Display();

            Console.WriteLine();// Spacing 
            Console.WriteLine("Clear List");
            singerList.Clear();// FUNCTION WORKS 
            singerList.Display();

            Console.WriteLine();
            Console.WriteLine();
        }
        public static void DoublyLinkedFunction()
        {

            Console.WriteLine("Doubly Linked List Functions");
            Console.WriteLine();
            DoublyLinkedList<string> top5singers = new DoublyLinkedList<string>();
            Console.WriteLine("TOP 5 SINGERS:");
            Console.WriteLine("*****************");
            top5singers.Add("Selena Gomez");// FUNCTION WORKS 
            top5singers.Add("William Singe");
            top5singers.Add("Justin Bieber");
            top5singers.Add("Tyneisha Keli");
            top5singers.Add("Paula DeAnda");
            top5singers.DisplayForward(); // Displaying list forward 
            
            Console.WriteLine();
            Console.WriteLine(); // Spacing 

            Console.WriteLine("TASK I: Display top 5 backwards");
            top5singers.DisplayBackward();

           
            Console.WriteLine();
            Console.WriteLine("TASK II: Display 6th place");
            top5singers.InsertAtEnd("Drake");
            top5singers.DisplayForward();

            Console.WriteLine();

            Console.WriteLine("TASK III: Magically, Jesse McCartney moved to #1, beating Selena");
            top5singers.InsertAtFront("Jesse McCartney");
            top5singers.DisplayForward();

            Console.WriteLine();

            Console.WriteLine("TASK IV: Drake magically makes it to #2 :O");
            top5singers.InsertAtIndex(1, "Drake"); 
            top5singers.RemoveAtEnd(); // Removing drake @ the end of the list 
            top5singers.DisplayForward();

            Console.WriteLine();
            Console.WriteLine("TASK V: Clear Top List");
            top5singers.Clear();
            top5singers.DisplayForward(); 

            Console.WriteLine();
            Console.WriteLine(); // Spacing 
        }
        public static void QueueFunctions()
        {
            Console.WriteLine("Queue Functions");
            Console.WriteLine("*****************");

            QueueList<string> listOfsingers = new QueueList<string>();
            Console.WriteLine();
            Console.WriteLine("Singers");
            Console.WriteLine("-------------------");
            listOfsingers.Enqueue("Miley Cyrus");
            listOfsingers.Enqueue("Mandy Moore");
            listOfsingers.Enqueue("Britney Spears");
            listOfsingers.Enqueue("Beyonce Knowles");
            listOfsingers.Enqueue("Frankie J");
            listOfsingers.Display();

            Console.WriteLine();
            Console.WriteLine("TASK I : Remove the first artist on the list");
            Console.WriteLine($"Dequeue Artist:{listOfsingers.Dequeue()}");
            listOfsingers.Display();

            Console.WriteLine();

            Console.WriteLine("TASK II: Since Dequeue was action, look at the first element");
            Console.WriteLine($"Peek @ the front Element: {listOfsingers.Peek()}");

            Console.WriteLine();
            Console.WriteLine("TASK IV: What's the count? ");
            Console.WriteLine($"The count is {listOfsingers.Count}");

            Console.WriteLine();
            Console.WriteLine();

        }
        public static void StackonStack()
        {
            Stack<string> stackSingers = new Stack<string>();
            Console.WriteLine("STACK FUNCTIONS");
            Console.WriteLine("----------------------------");
            stackSingers.Push("Miley Cyrus");
            stackSingers.Push("Mandy Moore");
            stackSingers.Push("Britney Spears");
            stackSingers.Push("Beyonce Knowles");
            stackSingers.Push("Frankie J");
            stackSingers.Display(); // Since its a stack, it will be placed backwards. The last placement is usually on top of the stack. 
            //Like a stack of dishes 

            Console.WriteLine("");
            Console.WriteLine("TASK I: Pop");
            stackSingers.Pop();
            stackSingers.Display();
            Console.WriteLine("Pop: To remove the top");
            Console.WriteLine("TASK II: Pop Twice");
            stackSingers.Pop();
            stackSingers.Display();
            Console.WriteLine("Implementing pop twice, removes the next part of the stack to be removed from the top");

            Console.WriteLine();
            Console.WriteLine("TASK III: Peek @ the top element");
            Console.WriteLine($"The top person on the stack is {stackSingers.Peek()}");
            Console.WriteLine("Britney Spears was initially the 3rd person but because we pop pop, she is the top");

            Console.WriteLine();
            Console.WriteLine("TASK IV: How many singers are there");
            Console.WriteLine($"There are current {stackSingers.Count} singers");


        }
    }
}
