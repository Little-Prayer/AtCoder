using System;
using System.Linq;

namespace C2
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var isAdult = Console.ReadLine().Select(c => c == '1').ToArray();
            var W = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var sortedW = W.Select((w, index) => (w, index)).OrderBy(c => c.w).ToArray();

            var current = isAdult.Where(b => b).Count();
            var max = current;

            for (int i = 0; i < N; i++)
            {
                current += isAdult[sortedW[i].index] ? -1 : 1;
                if (i < N - 1 && sortedW[i].w != sortedW[i + 1].w)
                    max = Math.Max(max, current);
            }
            max = Math.Max(max, current);
            Console.WriteLine(max);
        }
    }
}
