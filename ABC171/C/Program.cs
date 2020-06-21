using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine()) - 1;
            var digits = new List<long>();
            while (N > 26)
            {
                digits.Add(N % 26);
                N = N / 26;
            }
            digits.Add(N);
            digits.Reverse();
            for (int i = 0; i < digits.Count - 1; i++)
            {
                Console.Write((char)(digits[i] + 'a' - 1));
            }
            Console.Write((char)(digits[digits.Count - 1] + 'a'));
        }
    }
}
