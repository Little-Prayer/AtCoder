using System;
using System.Collections.Generic;
using System.Text;

namespace ABC109_D___Make_Them_Even
{
    static class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0];
            var W = HW[1];
            var map = new int[H + 1, W + 1];
            for (int i = 0; i < H; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < W; j++)
                {
                    map[i + 1, j + 1] = read[j];
                }
            }

            var moveCount = 0;
            var moveLog = new StringBuilder();
            for (int h = 1; h < H + 1; h++)
            {
                if (h.isOdd())
                {
                    if (map[h - 1, 1].isOdd())
                    {
                        moveCount++;
                        moveLog.AppendLine($"{h - 1} {1} {h} {1}");
                        map[h - 1, 1]--;
                        map[h, 1]++;
                    }
                    for (int w = 1; w < W; w++)
                    {
                        if (map[h, w].isOdd())
                        {
                            moveCount++;
                            moveLog.AppendLine($"{h} {w} {h} {w + 1}");
                            map[h, w]--;
                            map[h, w + 1]++;
                        }
                    }
                }
                else
                {
                    if (map[h - 1, W].isOdd())
                    {
                        moveCount++;
                        moveLog.AppendLine($"{h - 1} {W} {h} {W}");
                        map[h - 1, W]--;
                        map[h, W]++;
                    }
                    for (int w = W; w > 1; w--)
                    {
                        if (map[h, w].isOdd())
                        {
                            moveCount++;
                            moveLog.AppendLine($"{h} {w} {h} {w - 1}");
                            map[h, w]--;
                            map[h, w - 1]++;
                        }
                    }
                }
            }
            Console.WriteLine(moveCount);
            Console.Write(moveLog.ToString());
        }
        public static bool isOdd(this int n)
        {
            return n % 2 == 1;
        }
    }
}
