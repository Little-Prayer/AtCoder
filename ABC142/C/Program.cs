using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = new int[N];
            for (int i = 0; i < N; i++)
            {
                result[A[i] - 1] = i + 1;
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
