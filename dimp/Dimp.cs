using System;
using System.Collections.Generic;

namespace dimp
{
    public class Dimp
    {
        private LinkedList<DimKvp>[] _buckets;
        
        public Dimp()
        {
            _buckets = new LinkedList<DimKvp>[16];
        }

        public Dimp(int size)
        {
            _buckets = new LinkedList<DimKvp>[size];
        }

        public void Add(string key, object value)
        {
            int index = GetIndex(key); 
            if (_buckets[index] == null)
            {
                _buckets[index] = new LinkedList<DimKvp>();
                _buckets[index].AddLast(new DimKvp { Key = key, Value = value });
            }
        }

        private int GetIndex(string key)
        {
            int hash = key.GetHashCode();
            return Math.Abs(hash % _buckets.Length);
        }
    }
}