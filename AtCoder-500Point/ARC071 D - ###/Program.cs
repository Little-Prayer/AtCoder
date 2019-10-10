using System;

namespace ARC071_D______
{
    class Program
    {
        static void Main(string[] args)
        {
            var nm = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var n = nm[0]; var m = nm[1];
            var x = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var y = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long MOD = 1000000007;

            long Xsum = 0;
            for (int i = 0; i < n; i++)
            {
                Xsum += x[i] * i;
                Xsum -= x[i] * (n - i - 1);
                Xsum %= MOD;
            }

            long Ysum = 0;
            for (int i = 0; i < m; i++)
            {
                Ysum += y[i] * i;
                Ysum -= y[i] * (m - i - 1);
                Ysum %= MOD;
            }
            Console.WriteLine(Xsum * Ysum % MOD);
        }
    }
}
