using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var H = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            Console.WriteLine(H.OrderByDescending(n => n).Skip(K).Sum(n => n));
        }
    }
}
