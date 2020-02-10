using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var p = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var expected = p.Select(n => (decimal)n).Select(n => (n + 1) / 2).ToArray();

            Decimal sum = 0;
            for (int i = 0; i < K; i++) sum += expected[i];
            var result = sum;
            for (int i = 1; i + K - 1 < N; i++)
            {
                sum -= expected[i - 1];
                sum += expected[i + K - 1];
                if (sum > result) result = sum;
            }
            Console.WriteLine(result);
        }
    }
}
