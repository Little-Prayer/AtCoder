using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMK[0]; var M = NMK[1]; var K = NMK[2];
            long MOD = 998244353;

            var DP = new long[N + 1, K + 1];
            DP[0, 0] = 1;
            for (int cell = 0; cell < N; cell++)
            {
                for (int count = 1; count <= K; count++)
                {
                    for (int add = 1; add <= M; add++)
                    {
                        var back = 0;
                        var c = cell;
                        if (cell + add > N)
                        {
                            back = cell + add - N;
                            c = N - add;
                        }
                        DP[c + add - back, count] += DP[cell, count - 1];
                        DP[c + add - back, count] %= MOD;
                    }
                }
            }
            long modinv(long a)
            {
                long b = MOD;
                long u = 1;
                long v = 0;
                while (b > 0)
                {
                    long t = a / b;
                    a -= t * b;
                    var temp = a;
                    a = b;
                    b = temp;
                    u -= t * v;
                    temp = u;
                    u = v;
                    v = temp;
                }
                u %= MOD;
                if (u < 0) u += MOD;
                return u;
            }
            long result = 0;
            for (int i = 1; i <= K; i++)
            {
                if (DP[N, i] == 0) continue;
                long count = M;
                for (int c = 1; c < i; c++)
                {
                    count *= M;
                    count %= MOD;
                }
                result += (DP[N, i] * modinv(count)) % MOD;
                result %= MOD;
            }
            Console.WriteLine(result);
        }
    }
}
