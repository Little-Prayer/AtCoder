using System;

namespace D___Lamp
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var H = read[0];
            var W = read[1];
            
            string[] map = new string[H];
            for(int i = 0 ; i < H ; i++) map[i] = Console.ReadLine();
            
            var lightupLeft = new int[H,W];
            var lightupRight = new int[H,W];
            var lightupAbove = new int[H,W];
            var lightupBelow = new int[H,W];

            for(int h = 0 ; h < H ; h++)
            {
                lightupLeft[h,0] = map[h][0] == '#' ? 0 : 1;
                for(int w = 1 ; w < W ; w++)
                {
                    lightupLeft[h,w] = map[h][w] == '#' ? 0 : lightupLeft[h,w-1] + 1;
                }
            }

            for(int h = 0 ; h < H ; h++)
            {
                lightupRight[h,W-1] = map[h][W-1] == '#' ? 0 : 1;
                for(int w = W-2 ; w >= 0 ; w--)
                {
                    lightupRight[h,w] = map[h][w] == '#' ? 0 : lightupRight[h,w+1] + 1;
                }
            }

            for(int w = 0 ; w < W ; w++)
            {
                lightupAbove[0,w] = map[0][w] == '#' ? 0 : 1;
                for(int h = 1 ; h < H ; h++)
                {
                    lightupAbove[h,w] = map[h][w] == '#' ? 0 : lightupAbove[h-1,w] + 1;
                }
            }

            for(int w = 0 ; w < W ; w++)
            {
                lightupBelow[H-1,w] = map[H-1][w] == '#' ? 0 : 1;
                for(int h = H-2 ; h >= 0 ; h--)
                {
                    lightupBelow[h,w] = map[h][w] == '#' ? 0 : lightupBelow[h+1,w] + 1;
                }
            }

            var lightupTotal = new int[H,W];
            var lightupMax = 0;
            for(int h = 0 ; h < H ; h++)
            {
                for(int w = 0 ; w < W ; w++)
                {
                    lightupTotal[h,w] = lightupLeft[h,w] + lightupRight[h,w] +lightupAbove[h,w] + lightupBelow[h,w];
                    lightupMax = Math.Max(lightupMax,lightupTotal[h,w]);
                }
            }

            Console.WriteLine(lightupMax-3);
        }
    }
}
