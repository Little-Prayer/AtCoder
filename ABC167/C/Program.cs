using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NMX[0]; var M = NMX[1]; var X = NMX[2];
            var Ci = new int[N];
            var Aij = new int[N, M];
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Ci[i] = read[0];
                for (int j = 1; j < M + 1; j++) Aij[i, j - 1] = read[j];
            }

            var result = int.MaxValue;
            for (int i = 0; i < (1 << N); i++)
            {
                var study = new int[M];
                var amount = 0;
                for (int j = 0; j < N; j++)
                {
                    if ((i & (1 << j)) > 0)
                    {
                        amount += Ci[j];
                        for (int k = 0; k < M; k++)
                        {
                            study[k] += Aij[j, k];
                        }
                    }
                }
                var isSuccess = true;
                for (int l = 0; l < M; l++)
                {
                    if (study[l] < X)
                    {
                        isSuccess = false;
                        break;
                    }
                }
                if (isSuccess)
                {
                    result = Math.Min(result, amount);
                }
            }

            Console.WriteLine(result != int.MaxValue ? result : -1);
        }
    }
}
