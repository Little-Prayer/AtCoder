using System;

namespace ABC115_D___Christmas
{
    class Program
    {
        static long[] burger;
        static long[] patty;
        static void Main(string[] args)
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NX[0];
            var X = NX[1];

            burger = new long[N + 1];
            burger[0] = 1;
            for (int i = 1; i < N + 1; i++) burger[i] = burger[i - 1] * 2 + 3;

            patty = new long[N + 1];
            patty[0] = 1;
            for (int i = 1; i < N + 1; i++) patty[i] = patty[i - 1] * 2 + 1;

            Console.WriteLine(Eat(N, X));
        }

        static long Eat(long N, long X)
        {
            if (N == 0) return X == 1 ? 1 : 0;
            if (X <= burger[N - 1] + 1) return Eat(N - 1, X - 1);
            if (X == burger[N]) return patty[N];
            return 1 + patty[N - 1] + Eat(N - 1, X - 2 - burger[N - 1]);
        }
    }
}
