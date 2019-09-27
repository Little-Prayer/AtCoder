using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = new int[N];
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            A[0] = B[0];
            for (int i = 1; i < N - 1; i++)
            {
                A[i] = Math.Min(B[i], B[i - 1]);
            }
            A[N - 1] = B[N - 2];

            Console.WriteLine(A.Sum());
        }
    }
}
