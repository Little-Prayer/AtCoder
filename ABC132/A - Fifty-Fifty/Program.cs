using System;

namespace A___Fifty_Fifty
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
            if (S[0] == S[1])
                if (S[2] == S[3] && S[0] != S[2]) return true;
            if (S[0] == S[2])
                if (S[1] == S[3] && S[0] != S[1]) return true;
            if (S[0] == S[3])
                if (S[1] == S[2] && S[0] != S[1]) return true;
            return false;
        }
    }
}
