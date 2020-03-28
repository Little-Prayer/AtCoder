using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var KN = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var K = KN[0]; var N = KN[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var max = 0;
            for (int i = 1; i < N; i++)
            {
                max = Math.Max(max, A[i] - A[i - 1]);
            }
            max = Math.Max(A[0] + K - A[N - 1], max);

            Console.WriteLine(K - max);
        }
    }
}
