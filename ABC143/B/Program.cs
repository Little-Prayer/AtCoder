using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var d = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var result = 0L;

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    result += d[i] * d[j];
                }
            }
            Console.WriteLine(result);
        }
    }
}
