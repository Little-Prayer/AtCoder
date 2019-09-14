using System;
using System.Linq;
using System.Collections.Generic;

namespace COLOCON2018_D___すぬけそだて__トレーニング__
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (long i in solver()) Console.WriteLine(i);
        }
        static long[] solver()
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NX[0]; var X = NX[1];

            if (N == 1) return new long[] { X };

            var T = new long[N];
            T[0] = long.Parse(Console.ReadLine());
            var offset = new List<long>();
            offset.Add(X);
            for (int i = 1; i < N; i++)
            {
                T[i] = long.Parse(Console.ReadLine());
                offset.Add(Math.Min(X, T[i] - T[i - 1]));
            }

            var result = new long[N];
            result[N - 1] = offset.Sum();
            for (int K = N - 1; K > 0; K--)
            {
                var index = 0;
                var sum = long.MaxValue;
                for (int i = 1; i < K + 1; i++)
                {
                    if (sum > offset[i] + offset[i - 1])
                    {
                        sum = offset[i] + offset[i - 1];
                        index = i;
                    }
                }
                var newOffset = new List<long>();
                for (int i = 0; i < K + 1; i++)
                {
                    if (i == index - 1)
                    {
                        newOffset.Add(Math.Min(sum, X));
                    }
                    else if (i == index)
                    {

                    }
                    else
                    {
                        newOffset.Add(offset[i]);
                    }
                }

                result[K - 1] = newOffset.Sum();
                offset = newOffset;
            }

            return result;
        }
    }
}
