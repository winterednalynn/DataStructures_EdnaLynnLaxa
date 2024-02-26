using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures_EdnaLynnLaxa
{
    internal class DoublyLinkedList<T>
    {
        class DoublyLinkedListNode<T>
        {
            public T Value { get; set; } // Information saved in the node.
            public DoublyLinkedListNode<T> Next { get; set; }   // Refers to the next node.
            public DoublyLinkedListNode<T> Previous { get; set; } // Refers to the previous node.

            public DoublyLinkedListNode(T value) // T holds any type . 
            {
                Value = value; // Sets value variable as newly created node passed in the constructor 
                Next = null; // Initializes the next property , references to the next nodes as null 
                Previous = null; // Similar to next action , previous refers to the Previous node in list as node 
            }
        }

        private DoublyLinkedListNode<T> head; // Proper terminology for the start of list 
        private DoublyLinkedListNode<T> tail; // Proper terminology for the end of the list 
        private int count;

        public int Count
        {
            get { return count; }
        }

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // Add an element to the end of the list.
        public void Add(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            count++;
        }

        // Head to TGail dissplayer 
        public void DisplayForward()
        {
            DoublyLinkedListNode<T> current = head;
            while (current != null)
            {
                Console.Write($"{current.Value} *> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        // Tail to Head 
        public void DisplayBackward()
        {
            DoublyLinkedListNode<T> current = tail;
            while (current != null)
            {
                Console.Write($"{current.Value} *> ");
                current = current.Previous; // Deeming current as previous , which will flip flop the display 
            }
            Console.WriteLine("null");
        }

        // Remove an element by value.
        public bool Remove(T value)
        {
            DoublyLinkedListNode<T> current = head;

            while (current != null) // Travels through the list , (head is not equal to nul  
            {
                if (current.Value.Equals(value))
                {
                    if (current == head) head = head.Next; // If current node is the head pointer to go to next node 
                    if (current == tail) tail = tail.Previous;// if current node is the tail , it updates the tail pointer to the previous node 
                    if (current.Next != null) current.Next.Previous = current.Previous; // Updates previous pointer of the node prior to going the current node , which transition a skip of the current node 
                    if (current.Previous != null) current.Previous.Next = current.Next;

                    count--;// Since removal action is requested, the list is narrowed down, therefore decrements 
                    return true; // W/in the loop , it will stop the loop when the removal is terminated , the job of return true 
                }

                current = current.Next;
            }

            return false;
        }

        // Index Element access.
        public T this[int index]
        {
            get //Getter ; returning the value of target element 
            {
                if (index < 0 || index >= count) // Check if it's invalid range 
                    throw new IndexOutOfRangeException();

                DoublyLinkedListNode<T> current = head;//Initialized current variable as head of list to start
                for (int i = 0; i < index; i++)
                    current = current.Next;

                return current.Value;
            }
        }

        // Insert an element at a Target index.
        public void InsertAtIndex(int index, T value)
        {
            if (index < 0 || index > count)
            {
                //IF index is invalid , this wil prompt 
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value); // New object that can be inserted in the list

            //The new node needs to be inserted as the new head of the list if the index is 0.
            //transitions the new node's Next pointer to point to the head that is now in effect (newNode.Next = head).
            //updates the current head's Previous pointer to point to the new node (head.Previous = newNode) if the list wasn't empty.
            //modifies the list's head pointer to point to the newly added node (head = newNode).
            //update the tail pointer to point to the new node(tail = newNode) if the list was previously empty(count == 0).
            if (index == 0)
            {
                newNode.Next = head;

                if (head != null)
                {
                    head.Previous = newNode;
                }

                head = newNode;

                if (count == 0)
                {
                    tail = newNode;
                }
            }
            
            else if (index == count) // insert new node to tail of list. 
            {
                newNode.Previous = tail; // Creates a new previous pointer 
                tail.Next = newNode; //Updates the next pointer of the new node 
                tail = newNode; // Tail pointer is modified as the new node / new value 
            }
            //A zero index indicates that the new node needs to be inserted as the list's new head.
            //(newNode.Next = head) modifies the new node's Next pointer to point to the head as of in current.
            //Head.Previous = newNode; otherwise, update the current head's Previous pointer to
            //link to the new node if the list wasn't empty.
            //converts the list's head pointer (head = newNode) to point to the new node.
            //The tail pointer is also updated to point to the new node(tail = newNode) if the list was previously empty(count == 0).
            else
            {
                DoublyLinkedListNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                newNode.Previous = current;
                current.Next.Previous = newNode;
                current.Next = newNode;
            }
            // To add list , the list value increases, therefore count increments. 
            count++;
        }

        // Add a component to the list's beginning.
        public void InsertAtFront(T value)
        {
            InsertAtIndex(0, value);
        }

        // Add a component at the end of the list.
        public void InsertAtEnd(T value)
        {
            InsertAtIndex(count, value);
        }

        // Remove an element at a target index.
        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= count) // Checks if Index is w/in valid range. 
            {
                // If index is invalid , this will prompt 
                throw new ArgumentOutOfRangeException(nameof(index), "Out of range index .");
            }

            DoublyLinkedListNode<T> current = head; // Locating the node to removal, initializing current node as head pointer 

            if (index == 0) // If the index is 0 
            {
                //changes the head to point to current.Next, the second node in the list.
                //Sets the tail pointer to null as well if, after removing the head, the list is empty
                //(that is, the head is now null).
                head = current.Next;

                if (head != null)
                {
                    head.Previous = null;
                }

                if (count == 1)
                {
                    tail = null;
                }
            }
            //Eliminating the Tail: The tail node must be eliminated if the index equals count - 1.
            //modifies the tail pointer to point to the node(current.Previous) that comes before the tail.
            //as it is now the final element, sets the new tail node's Next pointer to null.
            else if (index == count - 1)
            {
                current = tail;
                tail = current.Previous;
                tail.Next = null;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }
            //Decrement count to reflect the removal 
            count--;
        }

        // Removal @ start of list 
        public void RemoveAtFront()
        {
            RemoveAtIndex(0);
        }

        // Removal @ end of list 
        public void RemoveAtEnd()
        {
            RemoveAtIndex(count - 1);
        }

        // Clear the whole list list 
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
    //  doubly linked lists provide efficiency and flexibility for some use cases requiring frequent
    //  insertion/deletion or bidirectional traversal. However, a singly linked list might be a
    //  simpler option if memory consumption is an issue and you only need to traverse the list in one direction.
}
