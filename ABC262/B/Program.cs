using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var link = new bool[N + 1, N + 1];
            for (int i = 0; i < M; i++)
            {
                var UV = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                link[UV[0], UV[1]] = true;
                link[UV[1], UV[0]] = true;
            }

            var count = 0;
            for (int i = 1; i <= N; i++)
            {
                for (int j = i + 1; j <= N; j++)
                {
                    for (int k = j + 1; k <= N; k++)
                    {
                        if (link[i, j] && link[j, k] && link[k, i]) count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
