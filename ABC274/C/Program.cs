using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var log = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = new int[2 * N + 2];
            result[1] = 0;
            for (int i = 1; i <= N; i++)
            {
                result[2 * i] = result[log[i - 1]] + 1;
                result[2 * i + 1] = result[log[i - 1]] + 1;
            }
            for (int i = 1; i < 2 * N + 2; i++) Console.WriteLine(result[i]);
        }
    }
}
