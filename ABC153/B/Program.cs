using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var HN = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HN[0];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(H <= A.Sum(n => n) ? "Yes" : "No");
        }
    }
}
