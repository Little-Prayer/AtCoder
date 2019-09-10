using System;
using System.Linq;
using System.Collections.Generic;

namespace COLOCON2018_D___すぬけそだて__トレーニング__
{
    class Program
    {
        static void Main(string[] args)
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NX[0]; var X = NX[1];

            var T = new int[N];
            T[0] = int.Parse(Console.ReadLine());
            var offset = new List<int>();
            offset.Add(X);
            for (int i = 1; i < N; i++)
            {
                T[i] = int.Parse(Console.ReadLine());
                offset.Add(Math.Min(X, T[i] - T[i - 1]));
            }

            var result = new int[N];
            result[N - 1] = offset.Sum();
            for (int K = N - 2; K > 0; K--)
            {
                var index = 0;
                var sum = int.MaxValue;
                for (int i = 0; i < K; i++)
                {
                    if (sum > offset[i] + offset[i + 1])
                    {
                        sum = offset[i] + offset[i + 1];
                        index = i;
                    }
                }
                var newOffset = new List<int>();
                for (int i = 0; i < K; i++)
                {
                    if (i == index)
                    {
                        newOffset.Add(Math.Max(sum, X));
                    }
                    else if (i == index + 1)
                    {
                        continue;
                    }
                    else
                    {
                        newOffset.Add(offset[i]);
                    }
                }

                result[K] = newOffset.Sum();
                offset = newOffset;
            }

            result[0] = X;
            foreach (int i in result) Console.WriteLine(i);
        }
    }
}
