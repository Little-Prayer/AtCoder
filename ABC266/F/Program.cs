using System;
using System.Collections.Generic;
using System.Linq;

namespace F
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var connection = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connection[i] = new List<int>();

            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[read[0]].Add(read[1]);
                connection[read[1]].Add(read[0]);
            }

        }
    }
}
