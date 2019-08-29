using System;
using System.Collections.Generic;
using System.Linq;

namespace ARC068_D___Card_Eater
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var cards = new Dictionary<int, int>();
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            foreach (int c in A)
            {
                if (!cards.ContainsKey(c)) cards.Add(c, 1); else cards[c]++;
            }

            int surplus = cards.Values.Sum(n => n - 1);
            if (surplus % 2 == 1) surplus++;
            Console.WriteLine(N - surplus);
        }
    }
}
