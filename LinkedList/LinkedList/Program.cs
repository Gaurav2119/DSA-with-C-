using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    public class LinkedList
    {
        private Node head;
        private int size;

        public LinkedList()
        {
            head = null;
            size = 0;
        }

        public int Size()
        {
            return size;
        }

        public void Insert(int data)
        {
            Node NewNode = new Node(data);
            if (head == null)
                head = NewNode;
            else
            {
                Node current = head;
                while (current.next != null)
                    current = current.next;
                current.next = NewNode;
            }
            size++;
        }

        public void InsertAtPosition(int data, int position)
        {
            if (position < 0 || position > size)
                throw new IndexOutOfRangeException();

            Node NewNode = new Node(data);
            if (position == 0)
            {
                NewNode.next = head;
                head = NewNode;
            }
            else
            {
                Node current = head;
                for (int i = 0; i < position - 1; i++)
                    current = current.next;
                NewNode.next = current.next;
                current.next = NewNode;
            }
            size++;
        }

        public void Delete(int data)
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");
            if (head.data == data)
            {
                head = head.next;
                size--;
                return;
            }
            Node current = head;
            while (current.next != null)
            {
                if (current.next.data == data)
                {
                    current.next = current.next.next;
                    size--;
                    return;
                }
                current = current.next;
            }
            throw new ArgumentException("Data not found");
        }

        public void DeleteAtPosition(int position)
        {
            if (position < 0 || position >= size)
                throw new IndexOutOfRangeException();
            if (position == 0)
                head = head.next;
            else
            {
                Node current = head;
                for (int i = 0; i < position - 1; i++)
                    current = current.next;
                current.next = current.next.next;
            }
            size--;
        }

        public int Center()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");
            Node slow = head;
            Node fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow.data;
        }

        public void Sort()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");
            for (Node i = head; i != null; i = i.next)
            {
                for (Node j = i.next; j != null; j = j.next)
                {
                    if (i.data > j.data)
                    {
                        int temp = i.data;
                        i.data = j.data;
                        j.data = temp;
                    }
                }
            }
        }

        public void Reverse()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");
            Node prev = null;
            Node current = head;
            while (current != null)
            {
                Node next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

        public int SizeofLinkedList()
        {
            int size = 0;
            Node current = head;
            while (current != null)
            {
                size++;
                current = current.next;
            }
            return size;
        }

        public void Traverse()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty");
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data + " ");
                current = current.next;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                LinkedList list = new LinkedList();
                try
                {
                    list.Insert(5);
                    list.Insert(10);
                    list.InsertAtPosition(7, 2);
                    Console.WriteLine("Linked List: ");
                    list.Traverse();
                    list.Delete(10);
                    list.DeleteAtPosition(0);
                    Console.WriteLine("Linked List: ");
                    list.Traverse();
                    Console.WriteLine("Size of Linked List: " + list.SizeofLinkedList());
                    Console.WriteLine("Center element: " + list.Center());
                    list.Insert(5);
                    list.Insert(10);
                    Console.WriteLine("Linked List: ");
                    list.Traverse();
                    list.Sort();
                    Console.WriteLine("Sorted Linked List: ");
                    list.Traverse();
                    list.Reverse();
                    Console.WriteLine("Reversed Linked List: ");
                    list.Traverse();
                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();
            }
        }
    }
}