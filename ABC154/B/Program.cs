using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var output = "";
            for (int i = 0; i < S.Length; i++) output += "x";
            Console.WriteLine(output);
        }
    }
}
