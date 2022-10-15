using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];

            var isFriend = new bool[N + 1, N + 1];

            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 1; j <= read[0]; j++)
                {
                    for (int k = j + 1; k <= read[0]; k++)
                    {
                        isFriend[read[j], read[k]] = true;
                        isFriend[read[k], read[j]] = true;
                    }
                }
            }

            var result = true;
            for (int i = 1; i <= N; i++)
            {
                for (int j = i + 1; j <= N; j++)
                {
                    if (!isFriend[i, j])
                    {
                        result = false;
                        break;
                    }
                }
                if (!result) break;
            }
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
