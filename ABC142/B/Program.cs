using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var h = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(h.Count(i => i >= NK[1]));
        }
    }
}
