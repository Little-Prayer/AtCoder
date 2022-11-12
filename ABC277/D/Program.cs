using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            Array.Sort(A);
            var set = new List<long>();
            var current = A[0];
            var currentSum = A[0];
            for (int i = 1; i < N; i++)
            {
                if (A[i] == current || A[i] == current + 1)
                {
                    currentSum += A[i];
                }
                else
                {
                    set.Add(currentSum);
                    currentSum = A[i];
                }
                current = A[i];
            }
            set.Add(currentSum);
            if (A[0] == 0 && A[N - 1] == M - 1)
            {
                set[0] += set[set.Count - 1];
                set[set.Count - 1] = 0;
            }
            Console.WriteLine(set.Sum() - set.Max());
        }
    }
}
