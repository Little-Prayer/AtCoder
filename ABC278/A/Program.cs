using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int i = 0; i < K; i++)
            {
                for (int j = 1; j < N; j++)
                {
                    A[j - 1] = A[j];
                }
                A[N - 1] = 0;
            }
            Console.WriteLine(string.Join(" ", A));
        }
    }
}
