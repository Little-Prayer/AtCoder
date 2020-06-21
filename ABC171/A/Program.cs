using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var alpha = char.Parse(Console.ReadLine());
            if ('A' <= alpha && alpha <= 'Z') Console.WriteLine("A");
            else Console.WriteLine("a");
        }
    }
}
