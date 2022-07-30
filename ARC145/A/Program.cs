using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            Console.WriteLine(solver(S) ? "Yes" : "No");
        }

        static bool solver(string S)
        {
            var arrayS = S.ToCharArray();
            if (S.Length == 2) return S[0] == S[1];

            if (S[0] == 'A' && S[S.Length - 1] == 'B') return false;

            return true;
        }
    }
}
