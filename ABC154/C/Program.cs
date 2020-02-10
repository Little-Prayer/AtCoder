using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var set = new HashSet<int>();
            foreach (int a in A) set.Add(a);

            Console.WriteLine(N == set.Count ? "YES" : "NO");
        }
    }
}
