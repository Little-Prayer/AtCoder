using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();

            var DP = new int[N, N];
            var len = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (S[i] == S[j])
                    {
                        if (i == 0)
                        {
                            DP[i, j] = 1;
                            len = 1;
                        }
                        else
                        {
                            DP[i, j] = Math.Min(DP[i - 1, j - 1] + 1, j - i);
                            len = Math.Max(len, DP[i, j]);
                        }
                    }
                }
            }

            Console.WriteLine(len);
        }
    }
}
