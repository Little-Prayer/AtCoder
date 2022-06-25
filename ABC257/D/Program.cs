using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var jump = new (int x, int y, int power)[N];
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                jump[i] = (read[0], read[1], read[2]);
            }
            var minS = new int[N];
            for (int i = 0; i < N; i++)
            {
                int current = int.MaxValue;
                for (int j = 0; j < N; j++)
                {
                    if (i == j) continue;
                    current = Math.Min(current, (Math.Abs(jump[i].x - jump[j].x) + Math.Abs(jump[i].y - jump[j].y) + jump[j].power - 1) / jump[j].power);
                }
                minS[i] = current;
            }
            Console.WriteLine(minS.OrderByDescending(n => n).Skip(1).First());
        }
    }
}