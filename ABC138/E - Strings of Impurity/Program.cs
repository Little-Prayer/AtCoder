using System;
using System.Collections.Generic;
namespace E___Strings_of_Impurity
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }

        static long solver()
        {
            var s = Console.ReadLine();
            var t = Console.ReadLine();

            var alphabets = new List<int>[26];
            for (int i = 0; i < 26; i++) alphabets[i] = new List<int>();
            for (int i = 0; i < s.Length; i++) alphabets[s[i] - 'a'].Add(i + 1);

            long result = 0;
            var currentIndex = 0;
            for (int i = 0; i < t.Length; i++)
            {
                var currentChar = alphabets[t[i] - 'a'];
                if (currentChar.Count == 0) return -1;
                currentIndex = binarySearch(currentChar, currentIndex);
                if (currentIndex == -1)
                {
                    result += s.Length;
                    currentIndex = currentChar[0];
                }
            }
            return result + currentIndex;
        }
        static int binarySearch(List<int> list, int key)
        {
            int left = -1;
            int right = list.Count;

            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] > key)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }
            if (right >= list.Count)
            {
                return -1;
            }
            else
            {
                return list[right];
            }
        }
    }
}
