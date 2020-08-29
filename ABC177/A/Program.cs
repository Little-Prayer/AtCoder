using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var DTS = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var D = DTS[0]; var T = DTS[1]; var S = DTS[2];
            Console.WriteLine(T * S >= D ? "Yes" : "No");
        }
    }
}
