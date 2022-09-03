using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            if (S == "Monday") Console.WriteLine("5");
            if (S == "Tuesday") Console.WriteLine("4");
            if (S == "Wednesday") Console.WriteLine("3");
            if (S == "Thursday") Console.WriteLine("2");
            if (S == "Friday") Console.WriteLine("1");
        }
    }
}
