using System;
using System.Linq;

namespace A___November_Festival
{
    class Program
    {
        static void Main(string[] args)
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NX[0]; var X = NX[1];
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var max = a.Max();
            Console.WriteLine(a.Count(n => n >= max - X));
        }
    }
}
