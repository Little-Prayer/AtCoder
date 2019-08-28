using System;
using System.Linq;
using System.Collections.Generic;

namespace ABC123_D___Cake_123別解
{
    class Program
    {
        static void Main(string[] args)
        {
            var XYZK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var K = XYZK[3];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();

            var cakes = new List<long>();
            for (int a = 0; a < A.Length; a++)
            {
                for (int b = 0; b < B.Length; b++)
                {
                    for (int c = 0; c < C.Length; c++)
                    {
                        if (a * b * c > K) break;
                        cakes.Add(A[a] + B[b] + C[c]);
                    }
                }
            }
            cakes = cakes.OrderByDescending(c => c).Take(K).ToList();
            foreach (long c in cakes) Console.WriteLine(c);
        }
    }
}
