using System;
using System.Collections.Generic;
using System.Linq;
using MethodImplOptions = System.Runtime.CompilerServices.MethodImplOptions;
using MethodImplAttribute = System.Runtime.CompilerServices.MethodImplAttribute;

namespace P___Independent_Set
{
    class Program
    {
        static List<int>[] connection;
        static int[] parent;
        static ModInt[,] DP;
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            connection = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connection[i] = new List<int>();

            parent = new int[N + 1];

            DP = new ModInt[N + 1, 2];
            for (int i = 0; i < N + 1; i++) for (int j = 0; j < 2; j++) DP[i, j] = 0;

            for (int i = 0; i < N - 1; i++)
            {
                var edge = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[edge[0]].Add(edge[1]);
                connection[edge[1]].Add(edge[0]);
            }
            Console.WriteLine(solver(1, 0) + solver(1, 1));
        }
        static ModInt solver(int currentNode, int isBlack)
        {
            if (DP[currentNode, isBlack] != 0) return DP[currentNode, isBlack];
            var kids = connection[currentNode].Where(s => s != parent[currentNode]).ToList();

            if (kids.Count == 0) return DP[currentNode, isBlack] = 1;

            ModInt result = 1;
            foreach (int kid in kids)
            {
                parent[kid] = currentNode;
                result *= (isBlack == 0 ? solver(kid, 1) : 0) + solver(kid, 0);
            }
            return DP[currentNode, isBlack] = result;
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
