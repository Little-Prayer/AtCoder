using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = int.Parse(Console.ReadLine());
            int count = X / 100;
            int fraction = X % 100;
            Console.WriteLine(count * 5 < fraction ? 0 : 1);
        }
    }
}
