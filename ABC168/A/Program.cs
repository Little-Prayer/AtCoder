using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            N %= 10;
            if ((N == 0) || (N == 1) || (N == 6) || (N == 8)) Console.WriteLine("pon");
            else if (N == 3) Console.WriteLine("bon");
            else Console.WriteLine("hon");
        }
    }
}
