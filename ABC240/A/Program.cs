using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var a = ab[0]; var b = ab[1];
            Console.WriteLine(Math.Abs(a - b) == 1 || Math.Abs(a - b) == 9 ? "Yes" : "No");
        }
    }
}
