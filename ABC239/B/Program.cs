using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = long.Parse(Console.ReadLine());
            var result = X / 10;
            if (X < 0 && (X % 10) != 0) result--;
            Console.WriteLine(result);
        }
    }
}
