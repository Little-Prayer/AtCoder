using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var result = 0L;
            for (long i = 1; i <= N; i++)
            {
                if ((i % 3) != 0 && (i % 5) != 0) result += i;
            }
            Console.WriteLine(result);
        }
    }
}
