using System;


namespace パ研杯2019_C___カラオケ
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];

            var table = new long[N, M];
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                for (int j = 0; j < M; j++)
                {
                    table[i, j] = read[j];
                }
            }

            long max = 0;
            for (int s1 = 0; s1 < M; s1++)
            {
                for (int s2 = s1 + 1; s2 < M; s2++)
                {
                    long result = 0;
                    for (int i = 0; i < N; i++)
                    {
                        result += Math.Max(table[i, s1], table[i, s2]);
                    }
                    if (result > max) max = result;
                }
            }
            Console.WriteLine(max);
        }
    }
}
