using System.Collections.Generic;

namespace Data_Structures.Part1
{
    public class CharFinderDictionary
    {
        private readonly Dictionary<string, int> _items = new Dictionary<string, int>();
        public string FirstNonDupliCharacters(string value)
        {
            var chars = value.ToCharArray();
            foreach (var chr in chars)
            {
                var str = chr.ToString();
                if (_items.TryGetValue(str, out var countValue))
                {
                    _items.Remove(str);
                    countValue += 1;
                    _items.Add(str, countValue);
                }
                else
                {
                    _items.Add(str, 1);
                }
            }
            foreach (var chr in chars)
            {
                var str = chr.ToString();
                if (_items.TryGetValue(str, out var count) && count == 1)
                {
                    return str;
                }
            }
            return string.Empty;
        }
        //My Way
        public string FirstDuplicateCharactersMyWay(string value)
        {
            var chars = value.ToCharArray();
            foreach (var chr in chars)
            {
                var str = chr.ToString();
                if (_items.TryGetValue(str, out var countValue))
                {
                    _items.Remove(str);
                    countValue += 1;
                    _items.Add(str, countValue);
                }
                else
                {
                    _items.Add(str, 1);
                }
            }
            foreach (var chr in chars)
            {
                var str = chr.ToString();
                if (_items.TryGetValue(str, out var count) && count != 1)
                {
                    return str;
                }
            }
            return "";
        }
        //Mosh Way
        public char FirstDuplicateCharactersMoshWay(string value)
        {
            var list = new HashSet<char>();
            foreach (var chr in value)
            {
                if (list.Contains(chr))
                {
                    return chr;
                }
                list.Add(chr);
            }
            return char.MaxValue;
        }
    }
}