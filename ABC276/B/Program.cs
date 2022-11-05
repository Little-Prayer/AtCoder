using System;
using System.Collections.Generic;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var connections = new List<int>[N + 1];
            for (int i = 0; i <= N; i++) connections[i] = new List<int>();
            for (int i = 0; i < M; i++)
            {
                var AB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connections[AB[0]].Add(AB[1]);
                connections[AB[1]].Add(AB[0]);
            }

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"{connections[i].Count} {string.Join(" ", connections[i].OrderBy(n => n))}");
            }
        }
    }
}
