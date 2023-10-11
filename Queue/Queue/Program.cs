using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Queue
{
    public class queue<T> : IEnumerable<T>
    {
        private List<T> items = new List<T>();
        public void enqueue(T item)
        {
            items.Add(item);
        }
        public T dequeue()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            T item = items[0];
            items.RemoveAt(0);
            return item;
        }
        public T peek()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            return items[0];
        }
        public bool contains(T item)
        {
            return items.Contains(item);
        }
        public int size()
        {
            return items.Count;
        }
        public T center()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            int centerIndex = items.Count / 2;
            return items[centerIndex];
        }
        public void sort()
        {
            items.Sort();
        }
        public void reverse()
        {
            items.Reverse();
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Traverse(Action<T> action)
        {
            foreach (T item in items)
                action(item);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            queue<string> q = new queue<string>();

            q.enqueue("apple");
            q.enqueue("cherry");
            q.enqueue("mango");

            Console.WriteLine("Size of queue: " + q.size());
            Console.WriteLine("Peek element: " + q.peek());
            Console.WriteLine("Contains cherry? " + q.contains("cherry"));
            q.Traverse(Console.WriteLine);

            q.sort();
            Console.WriteLine("Sorted order queue:");
            q.Traverse(Console.WriteLine);

            q.reverse();
            Console.WriteLine("Queue in reversed order:");
            q.Traverse(Console.WriteLine);

            Console.WriteLine("Queue center element: " + q.center());
            Console.WriteLine("Dequeue: " + q.dequeue());

            foreach (string item in q)
                Console.Write(item + " ");

            Console.ReadLine();
        }
    }
}
