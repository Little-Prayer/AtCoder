using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var digits = new List<long>();
            while (N > 0)
            {
                N -= 1;
                digits.Add(N % 26);
                N /= 26;
            }
            digits.Reverse();
            for (int i = 0; i < digits.Count; i++)
            {
                Console.Write((char)(digits[i] + 'a'));
            }
        }
    }
}
