using System;
using System.Linq;

namespace ABC155_D___Pairs
{
    class Program
    {
        static long[] A;
        static long[] reverseA;
        static int N;
        static long K;
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            N = NK[0]; K = NK[1];
            A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderBy(n => n).ToArray();
            reverseA = A.Reverse().ToArray();
        }

        static int CountLessThanX(long X)
        {
            var result = 0;
            foreach (long n in A)
            {
                var devide = X / n;
                var subtotal = lower_bound(-1, N, a => A[a] <= devide);
            }
        }
        static long lower_bound(long ng, long ok, Func<long, bool> pred)
        {
            while (Math.Abs(ng - ok) > 1)
            {
                long mid = (ok + ng) / 2;

                if (pred(mid)) ok = mid;
                else ng = mid;
            }
            return ok;
        }
    }
}
