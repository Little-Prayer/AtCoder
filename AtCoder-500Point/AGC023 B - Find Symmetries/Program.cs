using System;
using System.Collections.Generic;

namespace AGC023_B___Find_Symmetries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var N = int.Parse(Console.ReadLine());
            var baseBoard = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < N; j++) baseBoard[i, j] = read[j] - 'a';
            }

            var count = 0;
            for (int offset = 0; offset < N; offset++)
            {
                var offsetBoard = new int[N, N];
                for (int h = 0; h < N; h++) for (int w = 0; w < N; w++) offsetBoard[h, (w + offset) % N] = baseBoard[h, w];
                var isSymmetry = true;
                for (int h = 0; h < N; h++)
                {
                    for (int w = h; w < N; w++)
                    {
                        if (offsetBoard[h, w] != offsetBoard[w, h])
                        {
                            isSymmetry = false;
                            break;
                        }
                    }
                    if (!isSymmetry) break;
                }
                if (isSymmetry) count++;
            }
            return count * N;
        }
    }
}
