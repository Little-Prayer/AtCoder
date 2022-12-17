using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            for (int i = N; i >= 0; i--) Console.WriteLine(i);
        }
    }
}
