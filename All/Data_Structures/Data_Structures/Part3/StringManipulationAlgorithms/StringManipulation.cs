using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;

namespace Data_Structures.Part3.StringManipulationAlgorithms
{
    public class StringManipulation
    {
        private readonly char[] _vowels = { 'A', 'E', 'O', 'U', 'I' };
        //Vowels = A,E,O,U,I
        public int CountVowels(string message)
        {
            if (message == null)
                return 0;

            var count = 0;
            foreach (var chr in message.ToUpper())
            {
                if (_vowels.Contains(chr))
                    count++;
            }
            return count;
        }

        public string Reverse(string message)
        {
            if (message == null)
                return "";

            var reversed = new StringBuilder(capacity: message.Length);
            for (var i = message.Length - 1; i >= 0; i--)
                reversed.Append(message[i]);

            return reversed.ToString();
        }

        public string ReverseWords(string str)
        {
            if (str == null)
                return "";

            var words = str.Split(Convert.ToChar(" "));
            var reversed = new StringBuilder();
            for (var i = words.Length - 1; i >= 0; i--)
                reversed.Append(words[i] + " ");

            return reversed.ToString().Trim();
        }

        public bool Rotation(string first, string second)
        {
            return first.Length == second.Length && (first + first).Contains(second);
        }

        public string RemoveDublicate(string str)
        {
            if (str == null)
                return "";

            var output = new StringBuilder();
            var list = new HashSet<char>();
            foreach (var chr in str)
            {
                if (list.Contains(chr))
                {
                    continue;
                }
                output.Append(chr);
                list.Add(chr);
            }
            return output.ToString();
        }

        public char MostRepeated(string message)
        {
            if (string.IsNullOrEmpty(message))
                return ' ';

            var word = new int[256];
            foreach (var chr in message)
            {
                word[chr]++;
            }

            var max = 0;
            var output = ' ';
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] > max)
                {
                    max = word[i];
                    output = (char)i;
                }
            }
            return output;
        }

        public string SentenceCapitalization(string str)
        {
            if (!str.Trim().Any())
                return "";

            var words = str.Trim().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == String.Empty)
                    continue;

                words[i] = words[i].Substring(0, 1).ToUpper()
                           + words[i].Substring(1).ToLower() + " ";
            }
            return string.Join("", words);
        }

        //O(n log n)
        public bool AnagramsSortintg(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || str1.Length != str2.Length)
                return false;

            //O(n)
            var array1 = str1.ToLower().ToList();
            //O(n log n)
            array1.Sort();

            var array2 = str2.ToLower().ToList();
            array2.Sort();

            var index = 0;
            foreach (var item in array1)
            {
                if (item != array2[index])
                {
                    return false;
                }
                index++;
            }
            return true;
        }

        //O(n)
        public bool AnagramsCounting(string first, string second)
        {
            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
                return false;

            var result = new int[26];
            first = first.ToLower();
            //O(n)
            foreach (var item in first)
            {
                var index = item - 'a';
                result[index]++;
            }

            second = second.ToLower();
            //O(n)
            foreach (var item in second)
            {
                var index = item - 'a';
                if (result[index] == 0)
                {
                    return false;
                }
                result[index]--;
            }
            return true;
        }

        public bool PalindromeStack(string str)
        {
            var stack = new Stack<char>();

            foreach (var chr in str)
                stack.Push(chr);

            foreach (var chr in str)
                if (chr != stack.Pop())
                    return false;

            return true;
        }

        public bool PalindromeWhile(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            var left = 0;
            var right = str.Length - 1;
            while (left < right)
            {
                if (str[left++] != str[right--])
                    return false;
            }
            return true;
        }
    }
}