using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var x1 = points[0]; var y1 = points[1]; var x2 = points[2]; var y2 = points[3];

            var result = false;
            for (int x = -2; x <= 2; x++)
            {
                for (int y = -1; y <= 2; y++)
                {
                    if (x * x + y * y != 5) continue;
                    if ((x1 + x - x2) * (x1 + x - x2) + (y1 + y - y2) * (y1 + y - y2) == 5) result = true;
                }
            }
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
