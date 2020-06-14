using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var XN = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var X = XN[0]; var N = XN[1];
            if (N == 0) return X;
            var p = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int i = 0; i < 100; i++)
            {
                if (!p.Contains(X - i))
                {
                    return X - i;
                }
                if (!p.Contains(X + i))
                {
                    return X + i;
                }
            }
            return 0;
        }
    }
}
