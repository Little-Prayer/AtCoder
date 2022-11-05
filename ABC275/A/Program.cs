using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var max = 0;
            var result = 0;
            for (int i = 0; i < N; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                    result = i + 1;
                }
            }
            Console.WriteLine(result);
        }
    }
}
