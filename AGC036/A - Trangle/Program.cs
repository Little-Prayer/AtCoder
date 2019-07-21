using System;

namespace A___Trangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long S = long.Parse(Console.ReadLine());
            long x2, y2, x3, y3;
            x2 = (long)Math.Ceiling((decimal)Math.Sqrt(S));
            y3 = x2;
            if (x2 * y3 < S)
            {
                x2 += 1;
                y3 += 1;
            }
            x3 = x2 * y3 - S;
            y2 = x3 == 0 ? 0 : 1;
            Console.WriteLine($"0 0 {x2} {y2} {x3} {y3}");
        }
    }
}
