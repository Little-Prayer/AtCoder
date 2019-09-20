﻿using System;

namespace codeFlyer_D___ハンコ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solve());
        }
        static long solve()
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var H = HW[0]; var W = HW[1];
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var stamp = new bool[N, M];
            for (int i = 0; i < N; i++)
            {
                var A = Console.ReadLine();
                for (int j = 0; j < M; j++) stamp[i, j] = (A[j] == '#');
            }

            var compH = Math.Min(2 * N, H); var compW = Math.Min(2 * M, W);
            var compPaper = new int[compH, compW];
            for (int h = 0; h < N; h++)
            {
                for (int w = 0; w < M; w++)
                {
                    if (stamp[h, w] == '#')
                    {
                        compPaper[h, w]++;
                        compPaper[compH - N + h + 1, w]--;
                        compPaper[h, compW - M + w + 1]--;
                        compPaper[compH - N + h + 1, compW - M + w + 1]++;
                    }
                }
            }

            for (int h = 0; h < compH - 1; h++)
            {
                for (int w = 0; w < compW - 1; w++)
                {
                    compPaper[h + 1, w] += compPaper[h, w];
                    compPaper[h, w + 1] += compPaper[h, w];
                }
            }

            long result = 0;
            for (int h = 0; h < compH; h++)
            {
                for (int w = 0; w < compW; w++)
                {
                    if (compPaper[h, w] > 0) result++;
                }
            }



        }
    }
}
