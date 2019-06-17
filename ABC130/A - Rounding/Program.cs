using System;

namespace A___Rounding
{
    class Program
    {
        static void Main(string[] args)
        {
            var XA = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            Console.WriteLine(XA[0] < XA[1] ? 0:10);
        }
    }
}
