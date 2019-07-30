using System;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

namespace D___Digits_Parade
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var mod13 = new int[10, S.Length];
            for (int i = 0; i < 10; i++) mod13[i, 0] = i;
            for (int i = 1; i < S.Length; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mod13[j, i] = mod13[j, i - 1] * 10 % 13;
                }
            }
            var DP = new int[13, S.Length + 1];
            if (S[0] == '?')
            {
                for (int i = 0; i < 10; i++) DP[i, 0] = 1;
            }
            else
            {
                DP[int.Parse(S[0].ToString()), 0] = 1;
            }
            for (int i = 1; i < S.Length + 1; i++)
            {
                if (S[i] == '?')
                {
                    for (int Q = 0; Q < 10; Q++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            DP[(j + mod13[Q, i]) % 13, i] += DP[j, i - 1];
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < 10; j++) DP[(j + mod13[int.Parse(S[i].ToString())]) % 13, i] += DP[j, i - 1];
                }
            }
            Console.WriteLine(DP[5, S.Length]);
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
