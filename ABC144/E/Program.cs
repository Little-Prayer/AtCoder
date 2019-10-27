using System;
using System.Linq;

namespace E
{
    class Program
    {
        static long[] A;
        static long[] F;
        static long K;
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = (int)NK[0]; K = NK[1];
            A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            F = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            A = A.OrderBy(n => n).ToArray();
            F = F.OrderByDescending(n => n).ToArray();

            var result = lower_bound(1000000000000, judge);
            Console.WriteLine(result);
        }
        static bool judge(long key)
        {
            var target = F.Select(x => (long)(key / x)).ToArray();
            long count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                count += Math.Max(0, A[i] - target[i]);
            }
            return count <= K;
        }
        static long lower_bound(long length, Func<long, bool> pred)
        {
            long ng = -1;
            long ok = length;

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
