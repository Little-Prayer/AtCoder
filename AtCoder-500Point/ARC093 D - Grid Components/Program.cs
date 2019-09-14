using System;

namespace ABC093_D___Grid_Components
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = AB[0]; var B = AB[1];
            var isBlack = new bool[100, 100];
            for (int i = 0; i < 50; i++) for (int j = 0; j < 100; j++) isBlack[i, j] = true;
            for (int i = 50; i < 100; i++) for (int j = 0; j < 100; j++) isBlack[i, j] = false;

            var white = 1; var black = 1;

            for (int i = 0; i < 49; i += 2)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (white == A) break;
                    if ((i % 2) == (j % 2))
                    {
                        isBlack[i, j] = false;
                        white++;
                    }
                }
                if (white == A) break;
            }

            for (int i = 99; i > 50; i -= 2)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (black == B) break;
                    if ((i % 2) == (j % 2))
                    {
                        isBlack[i, j] = true;
                        black++;
                    }
                }
                if (black == B) break;
            }

            Console.WriteLine("100 100");
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(isBlack[i, j] ? "#" : ".");
                }
                Console.Write("\n");
            }
        }
    }
}
