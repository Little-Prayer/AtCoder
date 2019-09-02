using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var H = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var current = 0;
            var max = 0;
            for (int i = 1; i < N; i++)
            {
                if (H[i] <= H[i - 1])
                {
                    current++;
                }
                else
                {
                    max = Math.Max(current, max);
                    current = 0;
                }
            }
            max = Math.Max(current, max);
            current = 0;

            Console.WriteLine(max);
        }
    }
}
