using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NK[0]; var K = NK[1];
            long MOD = 1000000007;

            long result = 0;
            for (long i = K; i <= N + 1; i++)
            {
                var min = i * (i - 1) / 2;
                var max = i * (2 * N - i + 1) / 2;
                result += max - min + 1;
                result %= MOD;
            }
            Console.WriteLine(result);
        }
    }
}
