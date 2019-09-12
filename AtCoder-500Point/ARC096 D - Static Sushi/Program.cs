using System;

namespace ARC096_D___Static_Sushi
{
    class Program
    {
        static void Main(string[] args)
        {
            var NC = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NC[0]; var C = NC[1];

            var x = new long[N];
            var v = new long[N];
            for (int i = 0; i < N; i++)
            {
                var xv = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                x[i] = xv[0]; v[i] = xv[1];

            }
            var rx = new long[N];
            for (int i = 0; i < N; i++) rx[i] = C - x[N - i - 1];

            var cumV = new long[N + 1];
            var cumRV = new long[N + 1];
            for (int i = 1; i < N + 1; i++)
            {
                cumV[i] = cumV[i - 1] + v[i - 1];
                cumRV[i] = cumRV[i - 1] + v[N - i];
            }
            var max = new long[N + 1];
            var maxX = new long[N + 1];
            var maxR = new long[N + 1];
            var maxRX = new long[N + 1];
            for (int i = 1; i < N + 1; i++)
            {
                max[i] = Math.Max(max[i - 1], cumV[i] - x[i - 1]);
                maxX[i] = max[i] == max[i - 1] ? max[i - 1] : x[i - 1];
                maxR[i] = Math.Max(maxR[i - 1], cumRV[i] - rx[i - 1]);
                maxRX[i] = maxR[i] == maxR[i - 1] ? maxR[i - 1] : rx[i - 1];
            }

            long result = 0;
            for (int i = 1; i < N + 1; i++)
            {
                result = Math.Max(result, max[i] + maxR[N - i] - maxX[i]);
                result = Math.Max(result, max[i] + maxR[N - i] - maxRX[N - i]);
                result = Math.Max(result, max[i]);
                result = Math.Max(result, maxR[i]);
            }
            Console.WriteLine(result);
        }
    }
}
