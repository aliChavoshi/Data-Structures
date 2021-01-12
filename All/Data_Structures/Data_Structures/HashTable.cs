using System;
using System.Collections.Generic;

namespace Data_Structures
{
    public class HashTable
    {
        private readonly LinkedList<Entry>[] _entries = new LinkedList<Entry>[10];
        private class Entry
        {
            private int key;
            private string value;
            public Entry(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
            public int GetKey()
            {
                return key;
            }
            public string GetValue()
            {
                return value;
            }
            public void SetValue(string value)
            {
                this.value = value;
            }
        }
        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.SetValue(value);
                return;
            }
            var bucket = GetOrCreateBucket(key);
            bucket.AddLast(new Entry(key, value));
        }
        public bool ContainsKey(int key)
        {
            var entry = GetEntry(key);
            return entry != null;
        }
        public bool ContainsValue(string value)
        {
            if (_entries != null)
            {
                foreach (var linkedList in _entries)
                {
                    if (linkedList == null)
                    {
                        continue;
                    }
                    foreach (var entry in linkedList)
                    {
                        if (entry.GetValue() == value)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public string Get(int key)
        {
            var entry = GetEntry(key);
            return entry?.GetValue();
        }
        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if (entry == null)
                throw new Exception("Key Not Valid");

            GetBucket(key).Remove(entry);
        }
        private LinkedList<Entry> GetBucket(int key) => _entries[Hash(key)];
        private LinkedList<Entry> GetOrCreateBucket(int key)
        {
            var index = Hash(key);
            var bucket = _entries[index];
            if (bucket == null)
            {
                _entries[index] = new LinkedList<Entry>();
            }
            return _entries[index];
        }
        private Entry GetEntry(int key)
        {
            var bucket = GetBucket(key);
            if (bucket == null) return null;
            foreach (var entry in bucket)
            {
                if (entry.GetKey() == key)
                {
                    return entry;
                }
            }
            return null;
        }
        private int Hash(int key) => key % _entries.Length;
    }

}