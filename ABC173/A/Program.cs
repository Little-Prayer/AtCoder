using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            if ((N % 1000) == 0) Console.WriteLine(0);
            else Console.WriteLine(1000 - (N % 1000));


        }
    }
}
