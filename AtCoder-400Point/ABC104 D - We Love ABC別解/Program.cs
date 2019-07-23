using System;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

namespace ABC104_D___We_Love_ABC別解
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var accumA = new int[S.Length + 1];
            var accumC = new int[S.Length + 1];
            var accumQ = new int[S.Length + 1];
            for (int i = 0; i < S.Length; i++)
            {
                accumA[i + 1] = accumA[i] + (S[i] == 'A' ? 1 : 0);
                accumC[i + 1] = accumC[i] + (S[i] == 'C' ? 1 : 0);
                accumQ[i + 1] = accumQ[i] + (S[i] == '?' ? 1 : 0);
            }
            var totalA = accumA[S.Length];
            var totalC = accumC[S.Length];
            var totalQ = accumQ[S.Length];
            ModInt power3Q = 1;
            for (int i = 0; i < totalQ; i++) power3Q *= 3;
            ModInt power3Qminus1 = power3Q / 3;
            ModInt power3Qminus2 = power3Q / 9;
            ModInt power3Qminus3 = power3Q / 27;

            ModInt result = 0;
            for (int i = 1; i < S.Length; i++)
            {
                if (S[i - 1] == 'B')
                {

                }
                if (S[i - 1] == '?')
                {

                }
            }

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
