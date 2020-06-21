using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var p = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(p.OrderBy(n => n).Take(K).Sum(n => n));
        }
    }
}
