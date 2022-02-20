using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var H = double.Parse(Console.ReadLine());
            Console.WriteLine(Math.Sqrt(H * (12800000 + H)));
        }
    }
}
