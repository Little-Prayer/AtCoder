using System;

namespace CODE_FESTIVAL_2016_Grand_Final_C___Cheating_Nim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var N = int.Parse(Console.ReadLine());
            var piles = new int[N];
            var bits = new bool[30];
            for (int i = 0; i < N; i++)
            {
                piles[i] = int.Parse(Console.ReadLine());
                for (int j = 0; j < 30; j++)
                {
                    if ((piles[i] & (1 << j)) > 0)
                    {
                        bits[j] = true;
                        break;
                    }
                }
            }

            var xorSum = 0;
            foreach (int g in piles) xorSum ^= g;

            var result = 0;
            for (int bit = 29; bit >= 0; bit--)
            {
                if ((xorSum & (1 << bit)) == 0) continue;
                if (!bits[bit]) return -1;
                result++;
                xorSum ^= (1 << bit) - 1;
            }
            return result;
        }
    }
}
