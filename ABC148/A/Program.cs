using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = int.Parse(Console.ReadLine());
            var B = int.Parse(Console.ReadLine());
            if (A != 1 && B != 1) Console.WriteLine(1);
            if (A != 2 && B != 2) Console.WriteLine(2);
            if (A != 3 && B != 3) Console.WriteLine(3);
        }
    }
}
