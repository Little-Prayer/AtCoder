using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = int.Parse(Console.ReadLine());
            if (X <= 599) Console.WriteLine(8);
            else if (X >= 600 && X <= 799) Console.WriteLine(7);
            else if (X >= 800 && X <= 999) Console.WriteLine(6);
            else if (X >= 1000 && X <= 1199) Console.WriteLine(5);
            else if (X >= 1200 && X <= 1399) Console.WriteLine(4);
            else if (X >= 1400 && X <= 1599) Console.WriteLine(3);
            else if (X >= 1600 && X <= 1799) Console.WriteLine(2);
            else if (X >= 1800) Console.WriteLine(1);
        }
    }
}
