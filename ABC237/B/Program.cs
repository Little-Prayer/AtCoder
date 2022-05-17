using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var A = new int[H][];
            for (int i = 0; i < H; i++) A[i] = new int[W];
            var B = new int[W][];
            for (int i = 0; i < W; i++) B[i] = new int[H];

            for (int i = 0; i < H; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < W; j++) A[i][j] = read[j];
            }
            for (int i = 0; i < H; i++)
                for (int j = 0; j < W; j++)
                    B[j][i] = A[i][j];

            for (int i = 0; i < W; i++) Console.WriteLine(string.Join(" ", B[i]));

        }
    }
}
