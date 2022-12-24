using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];

            var isAnswer = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                var read = Console.ReadLine();
                for (int j = 0; j < M; j++)
                {
                    isAnswer[i, j] = (read[j] == 'o');
                }
            }

            var result = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    var current = true;
                    for (int k = 0; k < M; k++)
                    {
                        if (!(isAnswer[i, k] || isAnswer[j, k]))
                        {
                            current = false;
                            break;
                        }
                    }
                    if (current) { result++; }
                }
            }

            Console.WriteLine(result);
        }
    }
}
