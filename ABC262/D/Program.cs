using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var M = 998244353;

            long result = N;
            for (int C = 2; C <= N; C++)
            {
                var DP = new long[N + 1, C, C + 1];
                DP[0, 0, 0] = 1;
                var modA = A.Select(n => n % C).ToArray();

                for (int num = 1; num <= N; num++)
                {
                    for (int mod = 0; mod < C; mod++)
                    {
                        for (int count = 0; count <= C; count++)
                        {
                            DP[num, mod, count] += DP[num - 1, mod, count];
                            DP[num, mod, count] %= M;
                            if (count < C)
                            {
                                DP[num, (mod + modA[num - 1]) % C, count + 1] += DP[num - 1, mod, count];
                                DP[num, (mod + modA[num - 1]) % C, count + 1] %= M;
                            }
                        }
                    }
                }
                result += DP[N, 0, C];
                result %= M;
            }
            Console.WriteLine(result);
        }
    }
}
