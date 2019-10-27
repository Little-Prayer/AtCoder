using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            for (int i = (int)Math.Sqrt(N); i > 0; i--)
            {
                if (N % i == 0)
                {
                    long result = i + (N / i) - 2;
                    Console.WriteLine(result);
                    break;
                }
            }
        }
    }
}
