using System;
using System.Collections.Generic;
namespace E___Strings_of_Impurity
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var t = Console.ReadLine();

            var alphabets = new List<int>[26];
            for (int i = 0; i < 26; i++) alphabets[i] = new List<int>();
            for (int i = 0; i < s.Length; i++) alphabets[s[i] - 'a'].Add(i);
            var repeat = 0;
            var current = 0;
            for (int i = 0; i < t.Length; i++)
            {
                var before = current;
                foreach (int i in alphabets[t[0] - 'a'])
                {
                    if (current < i)
                    {
                        current = i;
                        break;
                    }
                }
            }
        }
    }
}
