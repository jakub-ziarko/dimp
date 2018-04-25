using System;
using System.Collections.Generic;

namespace dimp
{
    public class Dimp
    {
        private LinkedList<DimKvp>[] _buckets;
        private int _itemsCount;

        public int Count => _itemsCount;

        public Dimp()
        {
            _buckets = new LinkedList<DimKvp>[16];
        }

        public Dimp(int size)
        {
            _buckets = new LinkedList<DimKvp>[size];
        }

        public object this[string key]
        {
            get
            {
                int index = GetIndex(key);
                // Checking if index is outside of buckets boundries
                if (index > _buckets.Length - 1)
                {
                    return null;
                }

                // Chcek if the index is empty
                if (_buckets[index] == null)
                {
                    return null;
                }

                // Return first element when linked list have only one entry
                if (_buckets[index].Count == 1)
                {
                    return _buckets[index].First.Value.Value;
                }
                
                // Worst case when bucket has more then one entry
                foreach (var item in _buckets[index])
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                return null;
            }
        }

        public void Add(string key, object value)
        {
            int index = GetIndex(key); 
            // Avoiding collisions with the same result of hash
            if (_buckets[index] == null)
            {
                _buckets[index] = new LinkedList<DimKvp>();
                _buckets[index].AddLast(new DimKvp { Key = key, Value = value });
            }
            else
            {
                _buckets[index].AddLast(new DimKvp { Key = key, Value = value });
            }

            _itemsCount++;
        }

        private int GetIndex(string key)
        {
            int hash = key.GetHashCode();
            return Math.Abs(hash % _buckets.Length);
        }
    }
}