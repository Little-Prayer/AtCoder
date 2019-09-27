using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            int result = B[A[0] - 1];
            for (int i = 1; i < N; i++)
            {
                result += B[A[i] - 1];
                if (A[i] - A[i - 1] == 1) result += C[A[i - 1] - 1];
            }
            Console.WriteLine(result);
        }
    }
}
