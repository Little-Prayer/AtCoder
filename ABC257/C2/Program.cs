using System;
using System.Linq;

namespace C2
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var isAdult = Console.ReadLine().Select(c => c == '1');
            var W = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var sortedW = W.Select((w, index) => (w, index)).OrderBy(c => c.w).ToArray();
        }
    }
}
