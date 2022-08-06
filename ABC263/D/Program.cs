using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NLR = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NLR[0]; var L = NLR[1]; var R = NLR[2];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var accum = new long[N];
            var sumA = A.Sum();
            accum[0] = sumA - (A[0] - L);
            for (long i = 1; i < N - 1; i++) accum[i] = accum[i - 1] - (A[i] - L);
            long x = -1; long max = sumA;
            for (long i = 0; i < N - 1; i++)
            {
                if (max > accum[i])
                {
                    x = i;
                    max = accum[i];
                }
            }
            for (long i = 0; i <= x; i++) A[i] = L;

            var revAccum = new long[N];
            sumA = A.Sum();
            revAccum[N - 1] = sumA - (A[N - 1] - R);
            for (long i = N - 2; i >= 0; i--) revAccum[i] = revAccum[i + 1] - (A[i] - R);
            long y = N; long revMax = sumA;
            for (long i = N - 1; i >= 0; i--)
            {
                if (revMax > revAccum[i])
                {
                    revMax = revAccum[i];
                    y = i;
                }
            }
            Console.WriteLine(revMax);
        }
    }
}
