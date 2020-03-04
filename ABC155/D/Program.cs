using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var orMore0 = A.Where(n => n >= 0).OrderBy(n => n).ToList();
            var minus = A.Where(n => n < 0).OrderByDescending(n => n).ToList();
        }
    }
}
