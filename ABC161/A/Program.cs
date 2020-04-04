using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var abc = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{abc[2]} {abc[0]} {abc[1]}");
        }
    }
}
