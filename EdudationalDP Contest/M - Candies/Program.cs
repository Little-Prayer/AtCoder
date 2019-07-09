using System;
using System.Linq;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

namespace M___Candies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver().ToString());
        }
        static ModInt solver()
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0];
            var K = NK[1];
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            if (Ai.Sum() < K) return 0;

            var DP = new ModInt[N, K + 1];
            for (int i = 0; i <= Ai[0]; i++) DP[0, i] = 1;

            var cumlative = new ModInt[N, K + 1];
            cumlative[0, 0] = 1;
            for (int i = 1; i <= K; i++) cumlative[0, i] = cumlative[0, i - 1] + DP[0, i];

            for (int kids = 1; kids < N; kids++)
            {
                for (int candy = 0; candy <= Ai[kids]; candy++)
                    DP[kids, candy] = cumlative[kids - 1, candy];

                for (int candy = Ai[kids] + 1; candy <= K; candy++)
                    DP[kids, candy] = cumlative[kids - 1, candy] - cumlative[kids - 1, candy - Ai[kids] - 1];

                cumlative[kids, 0] = 1;
                for (int i = 1; i <= K; i++)
                    cumlative[kids, i] = cumlative[kids, i - 1] + DP[kids, i];
            }

            return DP[N - 1, K];
        }
    }



    //パクリ元　https://atcoder.jp/contests/arc067/submissions/5337727
    struct ModInt
    {
        const int MOD = 1000000007;
        long Data;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ModInt(long data) { if ((Data = data % MOD) < 0) Data += MOD; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long(ModInt modInt) => modInt.Data;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ModInt(long val) => new ModInt(val);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ModInt operator +(ModInt a, ModInt b)
        {
            long res = a.Data + b.Data;
            return new ModInt() { Data = res >= MOD ? res - MOD : res };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ModInt operator +(ModInt a, long b) => a.Data + b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ModInt operator -(ModInt a, ModInt b)
        {
            long res = a.Data - b.Data;
            return new ModInt() { Data = res < 0 ? res + MOD : res };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ModInt operator -(ModInt a, long b) => a.Data - b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ModInt operator *(ModInt a, ModInt b) => new ModInt() { Data = a.Data * b.Data % MOD };
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ModInt operator /(ModInt a, ModInt b) => a.Data * GetInverse(b);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => Data.ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static long GetInverse(long a)
        {
            long div;
            long p = MOD;
            long x1 = 1, y1 = 0, x2 = 0, y2 = 1;
            while (true)
            {
                if (p == 1) return x2;
                div = a / p;
                x1 -= x2 * div;
                y1 -= y2 * div;
                a %= p;
                if (a == 1) return x1;
                div = p / a;
                x2 -= x1 * div;
                y2 -= y1 * div;
                p %= a;
            }
        }
    }
}
