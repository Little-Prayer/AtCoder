using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            Console.WriteLine(N < 2147483648 && N >= -2147483648 ? "Yes" : "No");
        }
    }
}
