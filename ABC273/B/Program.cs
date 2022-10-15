using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var XK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var X = XK[0];
            var K = XK[1];

            for (int i = 0; i < K; i++)
            {
                if (X.ToString().Length - 1 < i) break;
                var current = int.Parse(X.ToString()[X.ToString().Length - 1 - i].ToString());
                if (current >= 5) X += (long)Math.Pow(10, i + 1);
                X -= current * (long)Math.Pow(10, i);
            }
            Console.WriteLine(X);
        }
    }
}