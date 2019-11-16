using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var factorial = 1;
            for (int i = 1; i <= N; i++) factorial *= i;
            var x = new int[N];
            var y = new int[N];
            for (int i = 0; i < N; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                x[i] = xy[0];
                y[i] = xy[1];
            }
            var sum = 0d;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    sum += Math.Sqrt(Math.Pow(x[i] - x[j], 2) + Math.Pow(y[i] - y[j], 2)) * factorial / N * 2;
                }
            }
            Console.WriteLine(sum / factorial);
        }
    }
}
