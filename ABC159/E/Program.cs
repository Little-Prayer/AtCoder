using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var HWK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HWK[0]; var W = HWK[1]; var K = HWK[2];
        }
    }
}
