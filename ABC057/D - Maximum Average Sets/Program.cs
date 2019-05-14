using System;
using System.Linq;

namespace D___Maximum_Average_Sets
{
    class Program
    {
        static void Main(string[] args)
        {
            var nab = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);

            var items = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            items = items.OrderByDescending(s => s).ToArray();

            var maxAve = items.Take(nab[1]).Average();
            Console.WriteLine(maxAve);
        }
    }
}
