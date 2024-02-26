using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_EdnaLynnLaxa
{
    public class SinglyLinkedList<T>
    {
        class SinglyLinkedListNode<T>
        {
            public T Value { get; set; } // data implemented in the node 
            public SinglyLinkedListNode<T> Next { get; set; } // Potrays the ref to the next data in the linked list. 


            public SinglyLinkedListNode(T value)
            {
                Value = value; // Setting data value in node 
                Next = null; // The initializer of the reference to the next node as null 
            }
        }
        //Fields 
        private SinglyLinkedListNode<T> head;
        private int count;

        //Property 
        public int Count
        {
            get { return count; }   // returns count 
        }

        //Constructor
        public SinglyLinkedList()
        {
            head = null; // head is the variable that is utilize to identify the first part of the node in the list, set to null b/c the list is empty
            count = 0; // Count set to none 
        }

        //To add an element to the list 

        public void Add(T value)
        {
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(value);

            // using a bool statement to check if the linked list is empty , looking if the start is empty 

            if (head == null)
            {
                head = newNode; // if the head is empty, new node will be @ the head of the list, start of the list 
            }
            else
            {
                //If the list is not deemed as empty then: 
                SinglyLinkedListNode<T> current = head;  // the comp will start @ the head 

                //Then it must travel through the list that has no node , using a while loop to go through the list 
                while (current.Next != null)
                {
                    current = current.Next; // Moving through the next node 
                }

                current.Next = newNode;
            }

            //Because an implementation is happening , the count increments. Therefore: 
            count++;
        }
        //Producing a method to dedicating displaying the contents of the linked list 

        public void Display()
        {
            // Initiate the list at the start 
            SinglyLinkedListNode<T> current = head;

            //Then travel the linked list and display all of it's contents using while loop 

            while (current != null)
            {
                Console.WriteLine(current.Value);

                // move over to the next item 
                current = current.Next;
            }
            Console.WriteLine("null"); // This will help dictate if the end of the list is seen 
        }
        //Producing a method to remove an element per value 
        public bool Remove (T value)
        {
            // To initiate action , we must check if the list is empty 

            if (head == null)
            {
                return false;   // if the list is empty then contents are not located & returned as false 
            }

            if (head.Value.Equals(value))
            {
                // when value is at the start , update the header to the next node and decrement the count 
                head = head.Next;
                count--;
                return true; // true when element is found and detail is terminated. 
            }

            // lets say the value is not at the head, then we start at the head! 
            SinglyLinkedListNode<T> current = head;

            // Travel through the list to locate the element w/ the specified value 

            while(current.Next!= null)
            {
                //Check if the next value is matched up to the target element 
                if(current.Next.Value.Equals(value))
                {
                    //If there is a match the skip the next node by updating the NEXT reference and decrement the count 
                    current.Next=current.Next.Next;
                    count--; 
                    return true; // If its found then it will be removed. 
                }
                current = current.Next;
            }
            return false; // When element is not located. 


        }
        //Override index to access elements by index 
        public T this[int index]
        {
            get
            {
                //Check if the aimed index is outside of range , will be deemed as negative, greater / equal to count of elements 
                if (index < 0 || index >=Count)
                {
                    throw new IndexOutOfRangeException(); 
                }

                SinglyLinkedListNode<T> current = head;

                // Travel the list and locate element that is targeted 
                for (int i = 0; i < index; i ++ )
                {
                    //transfer over to the next node in the list 
                    current = current.Next; 
                }
                return current.Value;   // Return the value of element that is located at aim index 

            }
            
        }
        public bool RemoveAt(int index)
        {
            // Check if the index is out of range
            if (index < 0 || index >= count)
            {
                return false;
            }

            // Removes the start , index 0 
            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                // goes through the list to find the data before the removal point
                SinglyLinkedListNode<T> current = head; 

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                // Skip the data to be removed and update the `Next` part 
                current.Next = current.Next.Next;
            }

            // decrement to update list
            count--;

            return true;
        }
        public void InsertAtIndex(T value, int index)
        {
            // Check if the index is out of range
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }

            // Create a new node with the given value
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(value);

            // Manges insertion at the start 
            if (index == 0)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                // Goes through the list to find the data before the introducing  point
                SinglyLinkedListNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                // Insert the new data after the current entry
                newNode.Next = current.Next;
                current.Next = newNode;
            }

            // The count is incremented, or updated 
            count++;
        }
        public void Clear()
        {
            while(head != null)
            {
                SinglyLinkedListNode<T> nextNode = head.Next;

                //Removed the head of the stack 
                head = null;

                //Travel to the next node 
                head = nextNode;

                //Decrease the count 
                count--; 
            }
        }



    }
}

