using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var lrd = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var l = lrd[0]; var r = lrd[1]; var d = lrd[2];
            var result = 0;
            for (int i = l; i <= r; i++)
            {
                if ((i % d) == 0) result++;
            }
            Console.WriteLine(result);
        }
    }
}
