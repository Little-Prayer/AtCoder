using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var L = double.Parse(Console.ReadLine());
            var l = L / 3;
            Console.WriteLine(l * l * l);
        }
    }
}
