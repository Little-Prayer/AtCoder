using System;
using System.Collections.Generic;

namespace COLOCON2018_D___すぬけそだて__トレーニング__
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in solver()) Console.WriteLine(i);
        }
        static int[] solver()
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NX[0]; var X = NX[1];

            if (N == 1) return new int[] { X };

            var T = new int[N];
            for (int i = 0; i < N; i++) T[i] = int.Parse(Console.ReadLine());

            var transition = new int[N];
            for (int i = 0; i < N; i++) transition[i] = lower_bound(T, T[i] + X);

            var DP = new int[N + 1, N + 1];
            DP[0, 1] = X;
            for (int t = 0; t < N; t++)
            {
                var trans = transition[t];
                for (int k = 1; k < N; k++)
                {
                    DP[trans, k + 1] = Math.Max(DP[trans, k + 1], DP[t, k] + X);
                    if (trans - 1 > t) DP[trans - 1, k + 1] = Math.Max(DP[trans - 1, k + 1], DP[t, k] + T[trans - 1] - T[t]);
                }
            }
            var result = new int[N];
            result[0] = X;
            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    result[i] = Math.Max(Math.Max(result[i], DP[j, i + 1]), result[i - 1]);
                }
            }
            return result;
        }
        static int lower_bound(int[] array, long key)
        {
            int left = -1;
            int right = array.Length;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] >= key) right = mid;
                else left = mid;
            }
            return right;
        }
    }
}
