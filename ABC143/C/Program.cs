using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();

            var result = N;
            for (int i = 1; i < N; i++)
            {
                if (S[i] == S[i - 1]) result--;
            }
            Console.WriteLine(result);
        }
    }
}
