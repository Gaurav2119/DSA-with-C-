using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Priority_Queue
{
    public class pQueue<T>
    {
        private List<Tuple<T, int>> items = new List<Tuple<T, int>>();
        public void enqueue(T item, int priority)
        {
            items.Add(new Tuple<T, int>(item, priority));
        }
        public T dequeue()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            int highestIndexPriority = 0;
            for (int i = 1; i < items.Count; i++)
                if (items[i].Item2 > items[highestIndexPriority].Item2)
                    highestIndexPriority = i;
            T item = items[highestIndexPriority].Item1;
            items.RemoveAt(highestIndexPriority);
            return item;
        }
        public T peek()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            int highestIndexPriority = 0;
            for (int i = 1; i < items.Count; i++)
                if (items[i].Item2 > items[highestIndexPriority].Item2)
                    highestIndexPriority = i;
            return items[highestIndexPriority].Item1;
        }
        public bool contains(T item)
        {
            foreach (Tuple<T, int> i in items)
                if (i.Item1.Equals(item))
                    return true;
            return false;
        }
        public int size()
        {
            return items.Count;
        }
        public T center()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Queue is empty");
            return items[items.Count / 2].Item1;
        }
        public void sort()
        {
            items.Sort((a, b) => a.Item2.CompareTo(b.Item2));
        }
        public void reverse()
        {
            items.Reverse();
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (Tuple<T, int> item in items)
                yield return item.Item1;
        }
        public void Traverse(Action<T> action)
        {
            foreach (Tuple<T, int> item in items)
                action(item.Item1);
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            pQueue<int> queue = new pQueue<int>();

            queue.enqueue(5, 2);
            queue.enqueue(10, 1);
            queue.enqueue(20, 3);
            queue.enqueue(15, 2);

            Console.WriteLine("Size: " + queue.size());
            Console.WriteLine("Peek: " + queue.peek());
            Console.WriteLine("Contains 10? " + queue.contains(10));

            queue.Traverse(item => Console.Write(item + " "));

            queue.sort();

            Console.WriteLine("Sorted:");

            foreach (int item in queue)
                Console.Write(item + " ");
            Console.WriteLine();

            queue.reverse();
            Console.WriteLine("Reversed:");

            foreach (int item in queue)
                Console.Write(item + " ");
            Console.WriteLine();

            Console.WriteLine("Center element: " + queue.center());

            Console.WriteLine("Dequeue: " + queue.dequeue());

            queue.Traverse(item => Console.Write(item + " "));

            Console.ReadLine();
        }
    }
}
