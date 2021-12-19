using System;

namespace _007___CP_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var Q = int.Parse(Console.ReadLine());

            Array.Sort(A);

            for (int i = 0; i < Q; i++)
            {
                var B = int.Parse(Console.ReadLine());
                var min = lower_bound(-1, (long)N, x => A[x] >= B);

                if (min == 0) Console.WriteLine(Math.Abs(B - A[min]));
                else if (min == N) Console.WriteLine(Math.Abs(B - A[min - 1]));
                else Console.WriteLine(Math.Min(Math.Abs(B - A[min]), Math.Abs(B - A[min - 1])));
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
