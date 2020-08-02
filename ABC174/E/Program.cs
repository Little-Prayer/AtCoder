using System;

namespace E
{
    class Program
    {
        static long[] A;
        static long K;
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NK[0]; K = NK[1];
            A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            long result = lower_bound(0, 1000000000, cutCount);
            Console.WriteLine(result);
        }

        static bool cutCount(long target)
        {
            long result = 0;
            foreach (int a in A)
            {
                result += ((a + target - 1) / target) - 1;
            }
            return result <= K;
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
