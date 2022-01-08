using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = long.Parse(Console.ReadLine());

            Console.WriteLine(fx(fx(fx(t) + t) + fx(fx(t))));

            long fx(long t)
            {
                return t * t + t * 2 + 3;
            }

        }
    }
}
