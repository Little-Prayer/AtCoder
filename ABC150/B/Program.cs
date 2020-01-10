using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var count = 0;
            for (int i = 2; i < N; i++)
            {
                if (S[i - 2] == 'A' && S[i - 1] == 'B' && S[i] == 'C') count++;
            }
            Console.WriteLine(count);
        }
    }
}
