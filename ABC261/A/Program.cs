using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var lrlr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var l1 = lrlr[0]; var r1 = lrlr[1]; var l2 = lrlr[2]; var r2 = lrlr[3];
            var red = new bool[101];
            var blue = new bool[101];
            for (int i = l1; i <= r1; i++) red[i] = true;
            for (int i = l2; i <= r2; i++) blue[i] = true;

            var count = 0;
            for (int i = 0; i < 101; i++) if (red[i] && blue[i]) count++;
            Console.WriteLine(Math.Max(count - 1, 0));
        }
    }
}
