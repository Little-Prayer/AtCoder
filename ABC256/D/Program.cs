using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var LR = new List<(int L, int R)>();
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                LR.Add((read[0], read[1]));
            }
            LR = LR.OrderBy(lr => lr.L).ToList();
            var result = new List<(int L, int R)>();
            var currentL = LR[0].L; var currentR = LR[0].R;
            foreach (var current in LR.Skip(1))
            {
                if (current.L > currentR)
                {
                    result.Add((currentL, currentR));
                    currentL = current.L;
                    currentR = current.R;
                    continue;
                }
                if (current.R > currentR) currentR = current.R;
            }
            result.Add((currentL, currentR));
            foreach (var lr in result) Console.WriteLine($"{lr.L} {lr.R}");
        }
    }
}
