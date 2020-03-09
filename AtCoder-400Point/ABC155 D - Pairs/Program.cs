using System;
using System.Linq;

namespace ABC155_D___Pairs
{
    class Program
    {
        static long[] A;
        static long[] reverseA;
        static long N;
        static long K;
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            N = NK[0]; K = NK[1];
            A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderBy(n => n).ToArray();
            reverseA = A.Reverse().ToArray();

            var result = lower_bound(-1000000000000000001, 1000000000000000001, a => CountLessThanX(a) >= K);
            Console.WriteLine(result);
        }

        static long CountLessThanX(long X)
        {
            long result = 0;
            foreach (long n in A)
            {
                if (n > 0)
                {
                    result += lower_bound(-1, N, a => n * A[a] > X);
                }
                else
                {
                    result += lower_bound(-1, N, a => n * reverseA[a] > X);
                }
                if (n * n <= X) result -= 1;
            }
            return result / 2;
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
