using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_EdnaLynnLaxa
{
    class Stack<T>
    {
        class StackNode<T>
        {
            public T Value { get; set; }       // Value of node              
            public StackNode<T> Next { get; set; } // TO the next node 

            public StackNode(T value)
            {
                Value = value; // The value 
                Next = null; // Next is null @ start 
            }
        }

        private StackNode<T> top; // Starter area 
        private int count; // count value 

        public int Count
        {
            get { return count; } // getter method for count 
        }

        public Stack()
        {
            top = null;// start of list is null 
            count = 0; // count is set to 0 
        }

        public void Push(T value) // Push Adds new element to the top of stack 
        {
            StackNode<T> newNode = new StackNode<T>(value);
            newNode.Next = top;
            top = newNode;
            count++; // Since things are added, the count is increased 
        }

        public T Pop() // Pop is like popping bubbles, you're terminating from the stack / removingb 
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty.");

            T value = top.Value;
            top = top.Next;
            count--; // removal action : count decrease, cause stack is smaller 
            return value;
        }

        public T Peek() // Grab a look @ the list from the start 
        {
            if (top == null) // 
                throw new InvalidOperationException("Stack is empty.");

            return top.Value;
        }

        public void Clear() // Remove everything
        {
            top = null;
            count = 0;
        }
        public void Display()
        {
            if (top==null)
            {
                Console.WriteLine("Empty Stack.");
            }
            else
            {
                ;

                // Iterate through the stack nodes from top to bottom
                StackNode<T> current = top;
                while (current != null)
                {
                    Console.Write(current.Value);
                    if (current.Next != null)
                    {
                        Console.Write(", " );
                    }
                    current = current.Next;
                }

                
            }
        }
    }
}

