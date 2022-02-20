using System;
using System.Collections.Generic;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var cuts = new List<int>();
            cuts.Add(0);
            cuts.Add(360);
            var current = 0;
            foreach (int c in A)
            {
                current += c;
                if (current >= 360) current -= 360;
                cuts.Add(current);
            }
            var max = 0;
            cuts = cuts.OrderBy(n => n).ToList();
            for (int i = 1; i < cuts.Count(); i++)
                max = Math.Max(max, cuts[i] - cuts[i - 1]);

            Console.WriteLine(max);
        }
    }
}
