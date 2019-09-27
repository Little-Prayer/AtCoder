using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            Console.WriteLine(solver(S) ? "Yes" : "No");
        }
        static bool solver(string S)
        {
            for (int i = 1; i < S.Length + 1; i++)
            {
                if (i % 2 == 1)
                {
                    if (S[i - 1] == 'L') return false;
                }
                else
                {
                    if (S[i - 1] == 'R') return false;
                }
            }
            return true;
        }
    }
}
