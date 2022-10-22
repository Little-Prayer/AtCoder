using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            Console.WriteLine(string.Format("{0:f3}", Math.Round(AB[1] / AB[0], 3)));
        }
    }
}
