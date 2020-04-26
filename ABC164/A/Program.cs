using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var SW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(SW[0] > SW[1] ? "safe" : "unsafe");
        }
    }
}
