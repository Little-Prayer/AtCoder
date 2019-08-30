using System;

namespace ARC074_C___Chocolate_Bar
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var H = HW[0];
            var W = HW[1];

            var S = long.MaxValue;
            for (int h = 1; h < H; h++)
            {
                var s1 = h * W;
                var s2 = Math.Max((int)((H - h) / 2) * W, (H - h) * (int)(W / 2));
                var s3 = H * W - s1 - s2;
                var smax = Math.Max(s1, Math.Max(s2, s3));
                var smin = Math.Min(s1, Math.Min(s2, s3));
                S = Math.Min(S, smax - smin);
            }
            for (int w = 1; w < W; w++)
            {
                var s1 = H * w;
                var s2 = Math.Max((int)(H / 2) * (W - w), H * (int)((W - w) / 2));
                var s3 = H * W - s1 - s2;
                var smax = Math.Max(s1, Math.Max(s2, s3));
                var smin = Math.Min(s1, Math.Min(s2, s3));
                S = Math.Min(S, smax - smin);
            }
            Console.WriteLine(S);
        }
    }
}
