using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var T = Console.ReadLine();
            var result = true;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != T[i])
                {
                    result = false;
                    break;
                }
            }
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
