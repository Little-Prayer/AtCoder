using System;
using System.Linq;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];
            var result = 0;
            for (int i = 0; i < H; i++) { result += Console.ReadLine().Where(c => c == '#').Count(); }

            Console.WriteLine(result);
        }
    }
}
