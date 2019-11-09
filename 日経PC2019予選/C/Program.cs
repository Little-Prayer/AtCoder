using System;
using System.Linq;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var sortA = A.OrderBy(n => n).ToArray();
            var sortB = B.OrderBy(n => n).ToArray();
            for (int i = 0; i < N; i++) if (sortA[i] > sortB[i]) return false;
            for (int i = 1; i < N; i++) if (sortA[i] <= sortB[i - 1]) return true;

            var dicA = new Dictionary<long, int>();
            var dicB = new Dictionary<long, int>();
            for (int i = 0; i < N; i++)
            {
                dicA.Add(sortA[i], i);
                dicB.Add(sortB[i], i);
            }

            var orderA = new int[N];
            var orderB = new int[N];
            for (int i = 0; i < N; i++)
            {
                orderA[i] = dicA[A[i]];
                orderB[i] = dicB[B[i]];
            }

            for (int i = 0; i < N; i++)
            {
                if (orderA[i] == orderB[i]) return true;
                if (orderB[i] == orderA[orderA[i]]) return true;
            }
            return false;
        }
    }
}
