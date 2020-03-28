using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = int.Parse(Console.ReadLine());
            var yen500 = X / 500;
            var yen5 = (X - (500 * yen500)) / 5;
            Console.WriteLine(yen500 * 1000 + yen5 * 5);
        }
    }
}
