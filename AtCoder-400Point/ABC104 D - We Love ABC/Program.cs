using System;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

namespace ABC104_D___We_Love_ABC
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var DP = new ModInt[S.Length + 1, 4];
            DP[0, 0] = 1;
            for (int i = 0; i < S.Length; i++)
            {
                for (int j = 0; j < 4; j++) DP[i + 1, j] = S[i] != '?' ? DP[i, j] : DP[i, j] * 3;
                if (S[i] == 'A' || S[i] == '?') DP[i + 1, 1] += DP[i, 0];
                if (S[i] == 'B' || S[i] == '?') DP[i + 1, 2] += DP[i, 1];
                if (S[i] == 'C' || S[i] == '?') DP[i + 1, 3] += DP[i, 2];
            }
            Console.WriteLine(DP[S.Length, 3]);
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
