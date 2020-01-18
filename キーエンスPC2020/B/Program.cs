using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var X = new int[N];
            var L = new int[N];
            var left = new int[N];
            var right = new int[N];
            for (int i = 0; i < N; i++)
            {
                var XL = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                X[i] = XL[0]; L[i] = XL[1];
                left[i] = X[i] - L[i];
                right[i] = X[i] + L[i];
            }
            var sortLeft = left.OrderBy(n => n).ToArray();
            var hitting = 0L;
            for (int i = 0; i < N; i++)
            {
                hitting += lower_bound(N, 0, (n) => { return sortLeft[n] < right[i]; }) - lower_bound(0, N, (n) => { return sortLeft[n] >= left[i]; }) - 1;
            }
            Console.WriteLine(N - hitting);
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
