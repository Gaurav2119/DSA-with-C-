using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace hash_table
{
    public class HashTable<K, V> : IEnumerable
    {
        private int size;
        private Node<K, V>[] buckets;

        private class Node<TKey, TValue>
        {
            public TKey key;
            public TValue value;
            public Node<TKey, TValue> next;
            public Node(TKey key, TValue value, Node<TKey, TValue> next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }

        public HashTable(int size)
        {
            this.size = size;
            this.buckets = new Node<K, V>[size];
        }

        public void Insert(K key, V value)
        {
            int index = Math.Abs(key.GetHashCode() % size);
            Node<K, V> node = buckets[index];
            while (node != null)
            {
                if(node.key.Equals(key))
                {
                    node.value = value;
                    return;
                }
                node = node.next;
            }
            buckets[index] = new Node<K, V>(key, value, buckets[index]);
        }

        public void Delete(K key)
        {
            int index = Math.Abs(key.GetHashCode() % size);
            Node<K, V> node = buckets[index];
            Node<K, V> prev = null;
            while (node != null)
            {
                if (node.key.Equals(key))
                {
                    if (prev == null)
                        buckets[index] = node.next;
                    else
                        prev.next = node.next;
                    return;
                }
                prev = node;
                node = node.next;
            }
        }

        public bool Contains(K key)
        {
            int index = Math.Abs(key.GetHashCode() % size);
            Node<K, V> node = buckets[index];
            while (node != null)
            {
                if (node.key.Equals(key))
                    return true;
                node = node.next;
            }
            return false;
        }

        public V GetValueByKey(K Key)
        {
            int index = Math.Abs(Key.GetHashCode() % size);
            Node<K, V> node = buckets[index];
            while (node != null)
            {
                if (node.key.Equals(Key))
                    return node.value;
                node = node.next;
            }
            throw new ArgumentException("Key not found");
        }

        public int Size
        {
            get { return size; }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                Node<K, V> node = buckets[i];
                while (node != null)
                {
                    yield return new KeyValuePair<K, V>(node.key, node.value);
                    node = node.next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Traverse()
        {
            foreach (KeyValuePair<K, V> pair in this)
                Console.WriteLine("{0} => {1}", pair.Key, pair.Value);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> table = new HashTable<string, int>(10);

            table.Insert("apple", 5);
            table.Insert("mango", 3);
            table.Insert("cherry", 7);

            Console.WriteLine("Table Size: {0}", table.Size);

            Console.WriteLine("Contains 'cherry: {0}", table.Contains("cherry"));

            Console.WriteLine("Value of apple: {0}", table.GetValueByKey("apple"));

            Console.WriteLine("Traversing table:");
            table.Traverse();

            table.Delete("mango");

            Console.WriteLine("Traversing table after deleting 'mango': ");
            table.Traverse();

            Console.ReadLine();
        }
    }
}
