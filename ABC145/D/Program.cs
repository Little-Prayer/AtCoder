using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var XY = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var X = XY[0]; var Y = XY[1];
            if ((X + Y) % 3 != 0) return 0;
            if (X > 2 * Y || Y > 2 * X) return 0;
            var moveX = 0; var moveY = 0;
            while (X * 2 != Y && Y * 2 != X)
            {
                X -= 3;
                Y -= 3;
                moveX++;
                moveY++;
            }
            moveX += Math.Min(X, Y);
            Combination.combInit(10000000, 1000000007);
            return Combination.combination(moveX + moveY, moveY);

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
