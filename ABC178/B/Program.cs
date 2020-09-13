using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var abcd = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var a = abcd[0]; var b = abcd[1]; var c = abcd[2]; var d = abcd[3];
            Console.WriteLine(Math.Max(a * c, Math.Max(b * c, Math.Max(a * d, b * d))));
        }
    }
}
