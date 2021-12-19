using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Array.Sort(A);

            for (int i = 0; i < NQ[1]; i++)
            {
                var x = int.Parse(Console.ReadLine());
                Console.WriteLine(NQ[0] - lower_bound(-1, NQ[0], i => x <= A[i]));
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
