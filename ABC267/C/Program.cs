using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NM[0]; var M = NM[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var MA = A.Select(n => n * M).ToArray();
            var subA = new long[N];
            long current = 0;
            for (int i = 0; i < N; i++)
            {
                if (i < M - 1)
                {
                    current += A[i];
                }
                else if (i == M - 1)
                {
                    current += A[i];
                    subA[i] = current;
                }
                else
                {
                    current += A[i];
                    current -= A[i - M];
                    subA[i] = current;
                }
            }

            long current2 = 0;
            for (int i = 0; i < M; i++) current2 += A[i] * (i + 1);
            long result = current2;
            for (long i = M; i < N; i++)
            {
                current2 += MA[i];
                current2 -= subA[i - 1];
                result = Math.Max(current2, result);
            }
            Console.WriteLine(result);

        }
    }
}
