using System;

namespace _015___Don_t_be_too_close_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            long mod = 1000000007;
            Combination.combInit(100000, mod);

            for (int k = 1; k <= N; k++)
            {
                long total = 0;

            }
        }
    }
    static class Combination
    {
        static long combMax;
        static long combMOD;

        static long[] factorial;
        static long[] inverse;
        static long[] factInv;

        public static void combInit(long _max, long _mod)
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

        public static long combination(int n, int k)
        {
            if (n < k) return 0;
            if (n < 0 || k < 0) return 0;
            return factorial[n] * (factInv[k] * factInv[n - k] % combMOD) % combMOD;
        }
    }
}
