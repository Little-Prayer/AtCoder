using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var abd = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            var a = abd[0]; var b = abd[1]; var d = abd[2];
            var ra = a * Math.Cos(d * (Math.PI / 180)) - b * Math.Sin(d * (Math.PI / 180));
            var rb = a * Math.Sin(d * (Math.PI / 180)) + b * Math.Cos(d * (Math.PI / 180));
            Console.WriteLine($"{ra} {rb}");
        }
    }
}
