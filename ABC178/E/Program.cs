using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var maxXplusY = long.MinValue;
            var maxXMinusY = long.MinValue;
            var minXplusY = long.MaxValue;
            var minXminusY = long.MaxValue;
            for (int i = 0; i < N; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var x = xy[0]; var y = xy[1];
                if (x + y > maxXplusY) maxXplusY = x + y;
                if (x + y < minXplusY) minXplusY = x + y;
                if (x - y > maxXMinusY) maxXMinusY = x - y;
                if (x - y < minXminusY) minXminusY = x - y;
            }
            Console.WriteLine(Math.Max(maxXplusY - minXplusY, maxXMinusY - minXminusY));
        }
    }
}
