using System;
using System.Collections.Generic;
using System.Linq;

namespace O___Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var matching = new List<List<bool>>();
            for (int i = 0; i < N; i++) matching[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).Select(s => s == 1).ToList();

        }
    }
}
