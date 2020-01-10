using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var halfA = A.Select(n => n / 2).ToArray();
            var minimumSCM = halfA[0];
            for (int i = 1; i < N; i++) minimumSCM = halfA[i] / GCD(minimumSCM, halfA[i]) * minimumSCM;
            for (int i = 0; i < N; i++) if (((minimumSCM / halfA[i]) % 2) == 0) return 0;
            if (((M / minimumSCM) % 2) == 0) return M / minimumSCM / 2;
            else return M / minimumSCM / 2 + 1;
        }
        static long GCD(long A, long B)
        {
            if (B > A) return GCD(B, A);
            if (A % B == 0)
            {
                return B;
            }
            else
            {
                return GCD(B, A % B);
            }
        }
    }
}
