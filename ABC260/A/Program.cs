using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            if (S[0] == S[1] && S[1] == S[2]) Console.WriteLine("-1");
            else if (S[0] == S[1]) Console.WriteLine(S[2]);
            else if (S[0] == S[2]) Console.WriteLine(S[1]);
            else if (S[1] == S[2]) Console.WriteLine(S[0]);
            else Console.WriteLine(S[0]);
        }
    }
}
