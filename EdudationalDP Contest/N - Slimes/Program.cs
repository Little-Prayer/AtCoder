﻿using System;

namespace N___Slimes
{
    class Program
    {
        static long[,] costs;
        static long[,] sizes;
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var slimes = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            costs = new long[N, N];
            for (int i = 0; i < N; i++) for (int j = 0; j < N; j++) costs[i, j] = -1;
            for (int i = 0; i < N; i++) costs[i, i] = 0;

            sizes = new long[N, N];
            for (int i = 0; i < N; i++) for (int j = 0; j < N; j++) sizes[i, j] = -1;
            for (int i = 0; i < N; i++) sizes[i, i] = slimes[i];
            for (int i = 0; i < N - 1; i++) for (int j = i + 1; j < N; j++) sizes[i, j] = sizes[i, j - 1] + sizes[j, j];


            Console.WriteLine(calcCost(0, N - 1));
        }
        static long calcCost(int start, int end)
        {
            if (costs[start, end] != -1) return costs[start, end];

            var result = long.MaxValue;
            for (int i = start; i + 1 <= end; i++)
            {
                result = Math.Min(result, calcCost(start, i) + calcCost(i + 1, end) + sizes[start, i] + sizes[i + 1, end]);
            }
            return costs[start, end] = result;
        }
    }
}
