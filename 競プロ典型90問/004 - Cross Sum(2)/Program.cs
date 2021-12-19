using System;

namespace _004___Cross_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];

            var map = new int[H, W];
            for (int h = 0; h < H; h++)
            {
                var row = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int w = 0; w < W; w++) map[h, w] = row[w];
            }

            var rowSum = new int[H];
            for (int h = 0; h < H; h++) for (int w = 0; w < W; w++) rowSum[h] += map[h, w];

            var columnSum = new int[W];
            for (int w = 0; w < W; w++) for (int h = 0; h < H; h++) columnSum[w] += map[h, w];

            var result = new int[H][];
            for (int i = 0; i < H; i++) result[i] = new int[W];
            for (int h = 0; h < H; h++) for (int w = 0; w < W; w++) result[h][w] = rowSum[h] + columnSum[w] - map[h, w];

            for (int h = 0; h < H; h++)
            {
                Console.WriteLine(string.Join(" ", result[h]));
            }
        }
    }
}
