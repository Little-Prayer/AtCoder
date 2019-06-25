using System;

namespace H___Grid_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0];
            var W = HW[1];

            int MOD = 1000000007;

            var grid = new string[H];
            for (int i = 0; i < H; i++) grid[i] = Console.ReadLine();

            var DP = new int[H, W];
            for (int i = 0; i < H; i++) for (int j = 0; j < W; j++) DP[i, j] = 0;
            for (int i = 0; i < H; i++) if (grid[i][1] == '.') DP[i, 1] = 1; else break;
            for (int j = 0; j < W; j++) if (grid[1][j] == '.') DP[1, j] = 1; else break;

            for (int i = 1; i < H; i++)
                for (int j = 1; j < W; j++)
                    if (grid[i][j] == '.') DP[i, j] = (DP[i - 1, j] + DP[i, j - 1]) % MOD;

            Console.WriteLine(DP[H - 1, W - 1]);
        }
    }
}
