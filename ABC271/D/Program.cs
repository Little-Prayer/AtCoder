using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            solver();
        }
        static void solver()
        {
            var NS = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NS[0]; var S = NS[1];

            var DP = new string[S + 1];
            var first = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            if (first[0] <= S) DP[first[0]] = "H";
            if (first[1] <= S) DP[first[1]] = "T";
            if (N == 1)
            {
                if (DP[S] is string && DP[S].Length == N)
                {
                    Console.WriteLine("Yes");
                    Console.WriteLine(DP[S]);
                }
                else
                {
                    Console.WriteLine("No");
                }
                return;
            }
            for (int i = 1; i < N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = S; j >= 1; j--)
                {
                    if (DP[j] is string && DP[j].Length == i)
                    {
                        if (j + ab[0] <= S) DP[j + ab[0]] = DP[j] + "H";
                        if (j + ab[1] <= S) DP[j + ab[1]] = DP[j] + "T";
                    }
                }
            }

            if (DP[S] is string && DP[S].Length == N)
            {
                Console.WriteLine("Yes");
                Console.WriteLine(DP[S]);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
