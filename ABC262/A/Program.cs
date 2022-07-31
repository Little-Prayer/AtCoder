using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var Y = int.Parse(Console.ReadLine());
            var result = 2002;
            while (Y > result) result += 4;
            Console.WriteLine(result);
        }
    }
}
