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
            if (S[0] == '1') return false;

            var column = new bool[7];
            column[0] = (S[6] == '1');
            column[1] = (S[4] == '1');
            column[2] = !(S[1] == '0' && S[7] == '0');
            column[3] = (S[4] == '1');
        }
    }
}
