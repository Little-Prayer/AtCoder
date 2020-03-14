using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var H = HW[0]; var W = HW[1];

            if (H == 1 || W == 1) return 1;

            var odd = (W + 1) / 2;
            var even = W / 2;

            var result = (odd * ((H + 1) / 2)) + (even * (H / 2));
            return result;
        }
    }
}
