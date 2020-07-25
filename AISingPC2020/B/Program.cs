using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = 0;
            for (int i = 0; i < N; i += 2)
            {
                if ((A[i] % 2) == 1) result++;
            }
            Console.WriteLine(result);
        }
    }
}
