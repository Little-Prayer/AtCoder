using System;

namespace AGC024_B___Backfront
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var check = new int[N + 1];
            var max = 0;
            for (int i = 0; i < N; i++)
            {
                var read = int.Parse(Console.ReadLine());
                check[read] = check[read - 1] + 1;
                max = Math.Max(check[read], max);
            }
            Console.WriteLine(N - max);
        }
    }
}
