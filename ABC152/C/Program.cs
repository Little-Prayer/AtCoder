using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var P = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var result = 0;
            var min = int.MaxValue;
            for (int i = 0; i < N; i++)
            {
                if (P[i] <= min)
                {
                    min = P[i];
                    result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
