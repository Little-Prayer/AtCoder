using System;

namespace D___Blue_and_Red_Balls
{
    class Program
    {
        static long MOD = 1000000007;
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0];
            var K = NK[1];
            combInit(2000, MOD);

            for (int i = 1; i <= K; i++)
            {
                var space = N - K + 1;
                var parts = combination(K - 1, i - 1);
                Console.WriteLine((combination(space, i) * parts) % MOD);
            }

        }

        static long combMax;
        static long combMOD;

        static long[] factorial;
        static long[] inverse;
        static long[] factInv;

        static void combInit(long _max, long _mod)
        {
            combMax = _max;
            combMOD = _mod;
            factorial = new long[combMax];
            inverse = new long[combMax];
            factInv = new long[combMax];

            factorial[0] = factorial[1] = 1;
            factInv[0] = factInv[1] = 1;
            inverse[1] = 1;

            for (int i = 2; i < combMax; i++)
            {
                factorial[i] = factorial[i - 1] * i % combMOD;
                inverse[i] = combMOD - inverse[combMOD % i] * (combMOD / i) % combMOD;
                factInv[i] = factInv[i - 1] * inverse[i] % combMOD;
            }
        }

        static long combination(int n, int k)
        {
            if (n < k) return 0;
            if (n < 0 || k < 0) return 0;
            return factorial[n] * (factInv[k] * factInv[n - k] % combMOD) % combMOD;
        }
    }
}
