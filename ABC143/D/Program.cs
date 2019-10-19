using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var L = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).OrderByDescending(n => n).ToArray();

            var result = 0;
            for (int a = N - 1; a >= 0; a--)
            {
                for (int b = a - 1; b >= 0; b--)
                {
                    var left = lower_bound(N, k => L[k] < L[a] + L[b]);
                    result += Math.Max(0, b - left);
                }
            }
            Console.WriteLine(result);
        }

        static int lower_bound(int length, Func<int, bool> pred)
        {
            int ng = -1;
            int ok = length;

            while (Math.Abs(ng - ok) > 1)
            {
                int mid = (ok + ng) / 2;

                if (pred(mid)) ok = mid;
                else ng = mid;
            }
            return ok;
        }
    }
}

