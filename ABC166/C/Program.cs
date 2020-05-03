using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var H = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var links = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) links[i] = new List<int>();
            for (int i = 0; i < M; i++)
            {
                var AB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                links[AB[0]].Add(AB[1]);
                links[AB[1]].Add(AB[0]);
            }
            var result = 0;
            for (int i = 1; i < N + 1; i++)
            {
                var isHighest = true;
                var currentHeight = H[i - 1];
                foreach (int h in links[i]) if (H[h - 1] >= currentHeight) isHighest = false;
                if (isHighest) result++;
            }
            Console.WriteLine(result);
        }
    }
}
