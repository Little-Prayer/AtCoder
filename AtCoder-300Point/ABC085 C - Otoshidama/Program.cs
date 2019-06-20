using System;

namespace ABC085_C___Otoshidama
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solve());
        }
        static string solve()
        {
            var NY = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NY[0];
            var Y = NY[1] / 1000;

            for (int k10 = 0; k10 <= N; k10++)
                for (int k5 = 0; k5 <= N - k10; k5++)
                    if (k10 * 10 + k5 * 5 + (N - k10 - k5) == Y)
                        return $"{k10} {k5} {N - k10 - k5}";

            return "-1 -1 -1";
        }
    }
}
