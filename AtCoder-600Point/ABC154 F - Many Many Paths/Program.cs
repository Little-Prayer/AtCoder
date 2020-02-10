using System;

namespace ABC154_F___Many_Many_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var r1 = read[0]; var c1 = read[1]; var r2 = read[2]; var c2 = read[3];
            var MOD = 1000000007;
            Combination.combInit(3000000, MOD);
            long temp1 = (Combination.combination(r2 + c2 + 2, c2 + 1) + Combination.combination(r1 + c1, c1)) % MOD;
            long temp2 = (Combination.combination(r2 + c1 + 1, c1) + Combination.combination(r1 + c2 + 1, c2 + 1)) % MOD;
            long result = (temp1 - temp2) % MOD;
            result = result < 0 ? result += MOD : result;
            Console.WriteLine(result);
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
