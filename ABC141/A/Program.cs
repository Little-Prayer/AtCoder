using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            Console.WriteLine(S == "Sunny" ? "Cloudy" : S == "Cloudy" ? "Rainy" : "Sunny");
        }
    }
}
