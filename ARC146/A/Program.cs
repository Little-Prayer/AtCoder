using System;
using System.Linq;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(String.Join("", A.OrderByDescending(n => n).Take(3).Select(n => n.ToString()).OrderByDescending(s => s).ToArray()));
        }
    }
}
