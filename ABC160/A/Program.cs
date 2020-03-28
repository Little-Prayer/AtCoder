using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            if (S[2] == S[3] && S[4] == S[5]) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
