using System;

namespace _1_Yokan_Party
{
    class Program
    {
        static private long[] A;
        static private long K;
        static private long L;
        static void Main(string[] args)
        {
            var NL = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NL[0]; L = NL[1];
            K = long.Parse(Console.ReadLine());
            A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            Console.WriteLine(lower_bound(L, 0, solver));
        }

        static bool solver(long size)
        {
            var lastCut = 0L;
            var cutCount = 0L;
            foreach (long i in A)
            {
                if (i - lastCut >= size)
                {
                    lastCut = i;
                    cutCount++;
                }
            }
            if (L - lastCut < size) cutCount--;
            return cutCount >= K;
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
