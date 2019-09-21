using System;
using System.Linq;

namespace キーエンスPC2019_D___Double_Landscape
{
    class Program
    {
        static long combMax;
        static long combMOD;

        static long[] factorial;
        static long[] inverse;
        static long[] factInv;
        static void Main(string[] args)
        {
            Console.WriteLine(solve());
        }
        static long solve()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var max = N * M;
            var Row = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var Column = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            long MOD = 1000000007;
            if (Row.Length != Row.Distinct().Count() || Column.Length != Column.Distinct().Count()) return 0;

            combInit(max, MOD);

            var isFixed = new bool[max + 1];
            var maxCount = new int[max + 1];
            for (int a = 0; a < N; a++)
            {
                for (int b = 0; b < M; b++)
                {
                    maxCount[Math.Min(Row[a], Column[b])]++;
                    if (Row[a] == Column[b]) isFixed[Row[a]] = true;
                }
            }

            var usedCount = 0;
            long result = 1;
            for (int i = 1; i < max + 1; i++)
            {
                if (maxCount[i] == 0) continue;
                if (i - usedCount < maxCount[i]) return 0;

                result *= combination(i - usedCount - 1, maxCount[i] - 1);
                result %= MOD;
                if (isFixed[i])
                {
                    result *= factorial[maxCount[i] - 1];
                    result %= MOD;
                }
                else
                {
                    result *= factorial[maxCount[i]];
                    result %= MOD;
                }
                usedCount += maxCount[i];
            }
            return result;
        }
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
