using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            for (int i = 0; i < S.Length; i++)
            {
                char offset = (char)(((S[i] - 'A' + N) % 26) + 'A');
                Console.Write(offset);
            }
        }
    }
}
