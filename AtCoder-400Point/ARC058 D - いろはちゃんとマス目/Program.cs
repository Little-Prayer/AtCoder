using System;

namespace ARC058_D___いろはちゃんとマス目
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = read[0];
            var W = read[1];
            var A = read[2];
            var B = read[3];
            long MOD = 1000000007;

            Combination.combInit(1000000, MOD);

            long result = 0;
            var h = H - A;
            var w = B + 1;
            var c = h + w;
            while (h >= 1 && w <= W)
            {
                result = (result + Combination.combination(c - 2, h - 1) * Combination.combination(H + W - c, H - h) % MOD) % MOD;
                h--;
                w++;
            }
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
