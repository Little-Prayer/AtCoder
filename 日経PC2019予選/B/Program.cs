using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var N = int.Parse(Console.ReadLine());
            var D = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            long MOD = 998244353;

            if (D[0] != 0) return 0;

            var distance = new long[D.Max() + 1];
            foreach (int d in D) distance[d] += 1;
            if (distance[0] != 1) return 0;
            long result = 1;
            for (int i = 1; i < distance.Length; i++)
            {
                for (int j = 0; j < distance[i]; j++)
                {
                    result *= distance[i - 1];
                    result %= MOD;
                }
            }
            return result;
        }
    }
}
