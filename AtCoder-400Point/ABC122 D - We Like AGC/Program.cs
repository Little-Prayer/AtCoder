using System;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

namespace ABC122_D___We_Like_AGC
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var DP = new ModInt[N + 1, 4, 4, 4];
            DP[0, 0, 0, 0] = 1;
            for (int n = 1; n < N + 1; n++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                if (j == 1 && k == 2 && l == 3) continue;
                                if (j == 2 && k == 1 && l == 3) continue;
                                if (j == 1 && k == 3 && l == 2) continue;
                                if (i == 1 && j == 2 && l == 3) continue;
                                if (i == 1 && k == 2 && l == 3) continue;
                                DP[n, j, k, l] += DP[n - 1, i, j, k];
                            }
                        }
                    }
                }
            }
            ModInt result = 0;
            for (int i = 0; i < 4; i++) for (int j = 0; j < 4; j++) for (int k = 0; k < 4; k++) result += DP[N, i, j, k];
            Console.WriteLine(result);
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
