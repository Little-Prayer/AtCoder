using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var count = 0;
            var i = 0;
            while (i < S.Length - i - 1)
            {
                if (S[i] != S[S.Length - i - 1]) count++;
                i++;
            }
            Console.WriteLine(count);
        }
    }
}
