using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var T = Console.ReadLine();

            if (S == "Y") Console.WriteLine(T.ToUpper());
            else Console.WriteLine(T);
        }
    }
}
