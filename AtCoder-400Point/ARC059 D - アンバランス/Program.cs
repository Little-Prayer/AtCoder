using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC059_D___アンバランス
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }

        static string solver()
        {
            var s = Console.ReadLine();
            var alphabetIndexes = new List<int>[26];
            if (s.Length == 2 && s[0] == s[1]) return "1 2";
            for (int i = 2; i < s.Length; i++)
            {
                if (s[i - 2] == s[i] || s[i - 1] == s[i])
                {
                    return ($"{i - 1} {i + 1}");
                }
            }
            return "-1 -1";
        }
    }
}
