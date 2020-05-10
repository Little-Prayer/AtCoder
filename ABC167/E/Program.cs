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
            Combination.combInit(1000000, MOD);
            long result = 0;
            for (int i = 0; i <= K; i++)
            {
                long subtotal = M;
                subtotal *= modpow(M - 1, N - i - 1, MOD);
                subtotal %= MOD;
                subtotal *= Combination.combination(N - 1, i);
                subtotal %= MOD;
                result += subtotal;
                result %= MOD;
            }
            Console.WriteLine(result);
        }
        static long modpow(long a, long n, long mod)
        {
            long result = 1;
            while (n > 0)
            {
                if ((n & 1) > 0) result = (result * a) % mod;
                a = (a * a) % mod;
                n >>= 1;
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
