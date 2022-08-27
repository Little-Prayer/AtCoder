using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMK[0]; var M = NMK[1]; var K = NMK[2];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            bool judge(int result)
            {
                var mask = 0;
                for (int i = 0; i <= 30; i++)
                {
                    if (result >= (2 << i))
                    {
                        mask += (2 << i);
                        break;
                    }
                }
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
