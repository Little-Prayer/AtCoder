using System;
using System.Collections.Generic;
using System.Linq;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var villeges = new List<(long x, long y, long p)>();
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                villeges.Add((read[0], read[1], read[2]));
            }
            var result = new int[N + 1];

            for (int i = 0; i < (1 << N); i++)
            {
                
            }
        }
        static long calcRange(List<long> trainX, List<long> trainY, List<(long x, long y, long p)> villeges)
        {
            long S = 0;
            foreach (var villege in villeges)
            {
                var minX = trainX.Min(x => Math.Abs(x - villege.x));
                var minY = trainY.Min(y => Math.Abs(y - villege.y));
                S += Math.Min(minX, minY) * villege.p;
            }
            return S;
        }
        static int popcount(int X)
        {
            var result = 0;
            while (X > 0)
            {
                if ((X % 2) == 1) result++;
                X /= 2;
            }
            return result;
        }
    }
}
