using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABX = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var A = ABX[0]; var B = ABX[1]; var X = ABX[2];
            var result = lower_bound(1000000001, (N) => N * A + N.ToString().Length * B <= X);
            Console.WriteLine(result == -1 ? 0 : result);
        }
        static long lower_bound(long length, Func<long, bool> pred)
        {
            long ok = -1;
            long ng = length;

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
