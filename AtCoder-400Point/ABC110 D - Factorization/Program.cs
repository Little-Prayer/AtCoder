using System;
using System.Collections.Generic;

namespace ABC110_D___Factorization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0];
            var M = NM[1];
            if (M == 1) return 1;

            var primeFactors = new List<int>();
            var factor = 2;
            long MOD = 1000000007;
            while (M > 1)
            {
                if (factor > Math.Sqrt(M))
                {
                    primeFactors.Add(M);
                    break;
                }
                while (M % factor == 0)
                {
                    M /= factor;
                    primeFactors.Add(factor);
                }
                factor += 1;
            }

            var primeCounts = new List<int>();
            primeCounts.Add(1);
            for (int i = 1; i < primeFactors.Count; i++)
                if (primeFactors[i] == primeFactors[i - 1])
                    primeCounts[primeCounts.Count - 1] += 1;
                else
                    primeCounts.Add(1);

            Combination.combInit(1000000, MOD);
            long result = 1;
            foreach (int i in primeCounts)
            {
                result *= Combination.combination(N + i - 1, i);
                result %= MOD;
            }
            return result;
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
