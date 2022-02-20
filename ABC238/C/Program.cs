using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            long mod = 998244353;
            long result = 0;
            long digit = 10;
            while (true)
            {
                if (N < digit) break;
                result += digit / 10 * 9 * (digit / 10 * 9 + 1) / 2;
                result %= mod;
                digit *= 10;
            }
            digit /= 10;
            Combination.combInit(10000, mod);
            long temp = (N - digit + 1) % mod;
            temp = temp * (temp + 1) * Combination.inverse[2];
            temp %= mod;
            result += temp;
            result %= mod;
            Console.WriteLine(result);

        }

    }
    static class Combination
    {
        static long combMax;
        static long combMOD;

        static long[] factorial;
        public static long[] inverse;
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
