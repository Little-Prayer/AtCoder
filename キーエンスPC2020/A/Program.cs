using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var H = int.Parse(Console.ReadLine());
            var W = int.Parse(Console.ReadLine());
            var N = int.Parse(Console.ReadLine());
            var paint = Math.Max(H, W);
            var count = 0;
            while (N > 0)
            {
                N -= paint;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
