using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = Console.ReadLine();
            if (N[0] == '7' || N[1] == '7' || N[2] == '7') Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
    }
}
