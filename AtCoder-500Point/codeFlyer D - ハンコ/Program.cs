using System;

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
            var compPaper = new int[compH + 1, compW + 1];
            for (int h = 0; h < N; h++)
            {
                for (int w = 0; w < M; w++)
                {
                    if (stamp[h, w])
                    {
                        compPaper[h, w]++;
                        compPaper[compH - N + h + 1, w]--;
                        compPaper[h, compW - M + w + 1]--;
                        compPaper[compH - N + h + 1, compW - M + w + 1]++;
                    }
                }
            }

            for (int h = 0; h < compH; h++)
            {
                for (int w = 0; w < compW; w++)
                {
                    compPaper[h + 1, w] += compPaper[h, w];
                }
            }
            for (int w = 0; w < compW; w++)
            {
                for (int h = 0; h < compH; h++)
                {
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

            var left = int.MaxValue; var right = int.MaxValue; var top = int.MaxValue; var bottom = int.MaxValue;
            for (int h = 0; h < N; h++)
            {
                for (int w = 0; w < M; w++)
                {
                    if (stamp[h, w])
                    {
                        left = Math.Min(left, w);
                        right = Math.Min(right, M - w - 1);
                        top = Math.Min(top, h);
                        bottom = Math.Min(bottom, N - h - 1);
                    }
                }
            }

            if (left != int.MaxValue)
            {
                result += (H - compH) * (W - right - left);
                result += (W - compW) * (H - top - bottom);
                result -= (H - compH) * (W - compW);
            }
            return result;
        }
    }
}
