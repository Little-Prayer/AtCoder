using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var isUsed = new bool[N + 1];
            var pairCount = 0;
            var offset = 1;
            for (int i = 1; i < N + 1; i++)
            {
                if (pairCount >= M) break;
                if (isUsed[i]) continue;
                if (i + offset > N) break;
                isUsed[i] = true;
                isUsed[i + offset] = true;
                Console.WriteLine($"{i} {i + offset}");
                offset++;
                pairCount++;
            }
        }
    }
}
