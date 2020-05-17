using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABHM = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            var A = ABHM[0]; var B = ABHM[1]; var H = ABHM[2]; var M = ABHM[3];
            var minute = 60 * H + M;
            var Hangle = 360 * minute / 720;
            var Mangle = 360 * M / 60;
            Console.WriteLine(Math.Sqrt(A * A + B * B - 2 * A * B * Math.Cos(Math.Abs(Hangle - Mangle) * Math.PI / 180)));
        }
    }
}
