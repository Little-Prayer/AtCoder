using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            for (int i = K + 1; i <= N; i++)
            {
                Console.WriteLine(A[i - K - 1] < A[i - 1] ? "Yes" : "No");
            }
        }
    }
}
