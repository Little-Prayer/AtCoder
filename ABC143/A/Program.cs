using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(Math.Max(0, AB[0] - 2 * AB[1]));
        }
    }
}
