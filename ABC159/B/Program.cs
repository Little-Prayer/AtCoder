using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var S = Console.ReadLine();
            for (int i = 0; i < (S.Length - 1) / 2; i++)
            {
                if (S[i] != S[S.Length - 1 - i]) return false;
            }
            for (int i = 0; i < (S.Length - 1) / 2; i++)
            {
                if (S[i] != S[(S.Length - 1) / 2 - i - 1]) return false;
            }
            return true;
        }
    }
}
