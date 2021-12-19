using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            Console.WriteLine(int.Parse(S[0].ToString()) * int.Parse(S[2].ToString()));
        }
    }
}
