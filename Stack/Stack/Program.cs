using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Stack
{
    class stack : IEnumerable
    {
        private object[] stackArray;
        private int top;

        public stack(int capacity)
        {
            stackArray = new object[capacity];
            top = -1;
        }

        public void Push(object item)
        {
            if (top == stackArray.Length - 1)
                throw new StackOverflowException("Stack overflow error");
            else
            {
                top++;
                stackArray[top] = item;
            }
        }

        public object Pop()
        {
            if (top == -1)
                throw new InvalidOperationException("Stack is empty");
            else
            {
                object item = stackArray[top];
                top = top - 1;
                return item;
            }
        }

        public object Peek()
        {
            if (top == -1)
                throw new InvalidOperationException("Stack is empty");
            else
                return stackArray[top];
        }

        public bool Contains(object item)
        {
            for (int i = 0; i <= top; i++)
            {
                if (stackArray[i].Equals(item))
                    return true;
            }
            return false;
        }

        public int Size()
        {
            return top + 1;
        }

        public object Center()
        {
            if (top == -1)
                throw new InvalidOperationException("Stack is empty");
            else
            {
                int centerIndex = top / 2;
                return stackArray[centerIndex];
            }
        }

        public void Sort()
        {
            Array.Sort(stackArray, 0, top + 1);
        }

        public void Reverse()
        {
            Array.Reverse(stackArray, 0, top + 1);
        }

        public IEnumerator<object> GetEnumerator()
        {
            foreach (object item in stackArray)
                yield return item;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Traverse(Action<object> action)
        {
            for (int i = top; i >= 0; i--)
                action(stackArray[i]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            stack sStack = new stack(5);
            sStack.Push("apple");
            sStack.Push("cheery");
            sStack.Push("banana");

            Console.WriteLine("Size of stack: " + sStack.Size());
            Console.WriteLine("Center item: " + sStack.Center());
            Console.WriteLine("Stack contains banana? " + sStack.Contains("banana"));
            Console.WriteLine("Items in stack:");
            sStack.Traverse(item => Console.WriteLine(item));

            sStack.Reverse();

            Console.WriteLine("Item in stack -- reversed:");
            sStack.Traverse(item => Console.WriteLine(item));

            sStack.Sort();
            Console.WriteLine("Item in stack -- sorted:");
            foreach (string item in sStack)
                Console.Write(item + " ");

            Console.WriteLine("\nPopping item off stack:");
            Console.WriteLine(sStack.Pop());
            
            Console.WriteLine();

            sStack.Traverse(item => Console.WriteLine(item));
            
            Console.ReadLine();
        }
    }
}
