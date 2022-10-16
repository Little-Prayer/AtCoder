using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Takahashi" : "Aoki");
        }
        static bool solver()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NM[0]; var M = (int)NM[1];
            if (N == M) return false;
            if (M == 0)
            {
                return ((N == 1) || (N == 3));
            }
            var start = new List<(long grid, bool isOne)>();
            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                start.Add((read[0], (read[1] == 1)));
            }

            var count = 0;
            if (start[0].grid == 2) count++;
            if (N - start[M - 1].grid > 1) return true;
            for (int i = 1; i < M; i++)
            {
                var distance = start[i].grid - start[i - 1].grid;
                if (distance > 3) return true;
                if (distance == 1) continue;
                if (distance == 2) if (start[i].isOne == start[i - 1].isOne) count++;
            }
            if (N - start[M - 1].grid == 1) count++;
            return ((count % 2) == 1);
        }
    }
}
