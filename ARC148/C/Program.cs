using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NQ[0]; var Q = NQ[1];
            var parent = new int[N + 1];
            var child = new int[N + 1];

            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int j = 0; j < N - 1; j++)
            {
                parent[j + 2] = read[j];
                child[read[j]]++;
            }


            var coin = new bool[N + 1];
            for (int i = 0; i < Q; i++)
            {
                for (int j = 0; j < N + 1; j++) coin[j] = false;
                var read2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 1; j <= read2[0]; j++) coin[read2[j]] = true;

                var count = 0;
                foreach (int r in read2.Skip(1))
                {
                    count += child[r];
                    if (coin[parent[r]]) count--;
                    else count++;
                }
                Console.WriteLine(count);
            }
        }
    }
}
