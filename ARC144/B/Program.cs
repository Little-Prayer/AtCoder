using System;
using System.Collections.Generic;
using System.Linq;
namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NAB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NAB[0]; var A = NAB[1]; var B = NAB[2];
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            bool judge(long target)
            {
                var countLow = Ai.Where(num => num < target).Select(num => (target - num + A - 1) / A).Sum();
                var countHigh = Ai.Where(num => num >= target).Select(num => (num - target) / B).Sum();
                return countLow <= countHigh;
            }
            Console.WriteLine(lower_bound(Ai.Max(), Ai.Min(), n => judge(n)));
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
