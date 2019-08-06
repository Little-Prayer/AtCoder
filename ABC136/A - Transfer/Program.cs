using System;

namespace A___Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(Math.Max(ABC[2] - ABC[0] + ABC[1], 0));
        }
    }
}
