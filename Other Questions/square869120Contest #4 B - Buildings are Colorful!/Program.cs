using System;

namespace square869120Contest__4_B___Buildings_are_Colorful_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            long result = long.MaxValue;

            for (long bit = 1; bit < Math.Pow(2, N); bit++)
            {
                if (popcount(bit) != K) continue;

                var max = 0;
                long cost = 0;
                for (int building = 0; building < N; building++)
                {
                    if (max < A[building])
                    {
                        max = A[building];
                        continue;
                    }
                }
            }
        }

        static int popcount(long X)
        {
            int result = 0;
            while (X > 0)
            {
                if ((X % 2) == 1) result++;
                X /= 2;
            }
            return result;
        }
    }
}
