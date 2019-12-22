using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var A = new int[H, W];
            var B = new int[H, W];
            for (int i = 0; i < H; i++)
            {
                var aw = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < W; j++) A[i, j] = aw[j];
            }
            for (int i = 0; i < H; i++)
            {
                var bw = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < W; j++) B[i, j] = bw[j];
            }

            var N = new int[H + 1, W + 1];
            var max = 0;
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    N[i + 1, j + 1] = Math.Abs(A[i, j] - B[i, j]);
                    max = Math.Max(N[i + 1, j + 1], max);
                }
            }

            max *= H + W;

            bool[,,] map = new bool[max + 1, H + 1, W + 1];
            map[N[1, 1], 1, 1] = true;

            for (int h = 1; h < H + 1; h++)
            {
                for (int w = 1; w < W + 1; w++)
                {
                    for (int n = 0; n <= max; n++)
                    {
                        if (map[n, h - 1, w] || map[n, h, w - 1])
                        {
                            map[Math.Abs(N[h, w] - n), h, w] = true;
                            map[N[h, w] + n, h, w] = true;
                        }
                    }
                }
            }
            for (int n = 0; n <= max; n++)
            {
                if (map[n, H, W])
                {
                    Console.WriteLine(n);
                    break;
                }
            }
        }
    }
}
