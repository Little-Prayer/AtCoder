using System;

namespace ARC064_D___An_Ordinary_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            Console.WriteLine(((S.Length % 2) == 0) ^ (S[0] == S[S.Length - 1]) ? "Second" : "First");
        }
    }
}
