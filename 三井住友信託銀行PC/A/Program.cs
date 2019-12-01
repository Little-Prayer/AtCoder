using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var md1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var md2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(md1[0] == md2[0] ? 0 : 1);
        }
    }
}
