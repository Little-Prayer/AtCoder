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
            var DP = new ModInt[N + 1, 4];
            for (int i = 0; i < 4; i++)
            {
                DP[1, i] = 1;
                DP[2, i] = 4;
            }
            DP[3, 0] = 16;
            DP[3, 1] = 14;
            DP[3, 2] = 15;
            DP[3, 3] = 16;
            for (int i = 4; i < N + 1; i++)
            {
                DP[i, 0] += DP[i - 3, 0] * 14;
                DP[i, 0] += DP[i - 3, 1] * 16;
                DP[i, 0] += DP[i - 3, 2] * 15;
                DP[i, 0] += DP[i - 3, 3] * 16;
                DP[i, 1] += DP[i - 3, 0] * 9;
                DP[i, 1] += DP[i - 3, 1] * 13;
                DP[i, 1] += DP[i - 3, 2] * 13;
                DP[i, 1] += DP[i - 3, 3] * 14;
                DP[i, 2] += DP[i - 3, 0] * 14;
                DP[i, 2] += DP[i - 3, 1] * 15;
                DP[i, 2] += DP[i - 3, 2] * 15;
                DP[i, 2] += DP[i - 3, 3] * 15;
                DP[i, 3] += DP[i - 3, 0] * 14;
                DP[i, 3] += DP[i - 3, 1] * 16;
                DP[i, 3] += DP[i - 3, 2] * 15;
                DP[i, 3] += DP[i - 3, 3] * 16;

            }
            Console.WriteLine(DP[N, 0] + DP[N, 1] + DP[N, 2] + DP[N, 3]);
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
