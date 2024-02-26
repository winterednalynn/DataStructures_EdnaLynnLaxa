using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_EdnaLynnLaxa
{
   public class QueueList<T>
    {
        class QueueNode<T>
        {
            public T Value { get; set; }
            public QueueNode<T> Next { get; set; }
            public QueueNode<T> Previous { get; set; }

            public QueueNode(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }


        private QueueNode<T> front;
        private QueueNode<T> rear;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public QueueList()
        {
            front = null; // Front is null -- to start 
            rear = null;  // rear is null --- To start 
            count = 0;   // count is set @ 0 
        }

        public void Enqueue(T value)
        {
            QueueNode<T> newNode = new QueueNode<T>(value);

            if (rear == null)
            {
                // the new value is implemented in place of placement : f & r 
                front = newNode;
                rear = newNode;
            }
            else
            {

                rear.Next = newNode;
                newNode.Previous = rear;

                rear = newNode;
            }

            count++; // B/C enqueue is add ; the list increases, therefor count increments 
        }

        public T Dequeue()
        {
            if (front == null)
                throw new InvalidOperationException("Queue is empty."); // Empty checker 

            T value = front.Value; // 
            // Front part , goes next 
            front = front.Next;

            if (front == null)
                rear = null; // If the list transition as empty, move the rear too 
            else
                front.Previous = null; // Removal of target 

            count--; // B/C Dequeue is an action of removal, the list decreases , therefore count decrements. 
            return value; // Return the removal value 








        }

        public T Peek()
        {
            if (front == null)
                throw new InvalidOperationException("Empty Queue."); // Check for an empty queue.

            return front.Value;
        }

        public void Display()
        {
            if (front==null)
            {
                Console.WriteLine("The queue is empty.");
            }
            else
            {
                Console.Write(": **");

                // Iterate through the queue nodes
                QueueNode<T> current = front;
                while (current != null)
                {
                    Console.Write(current.Value);
                    if (current.Next != null)
                    {
                        Console.Write(", ");
                    }
                    current = current.Next;
                }

                Console.WriteLine("**");
            }
        }


        public void Clear()
        {
            front = null; // Set to none .
            rear = null; // Set to none 
            count = 0; // Sets count to 0 
        }
    }
}


