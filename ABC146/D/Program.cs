using System;
using System.Linq;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var a = new int[N - 1]; var b = new int[N - 1];
            var edges = new int[N + 1];
            for (int i = 0; i < N - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                a[i] = ab[0]; b[i] = ab[1];
                edges[ab[0]] += 1;
                edges[ab[1]] += 1;
            }
            var colorMax = edges.Max();
            var adjColors = new List<int>[N + 1];
            var colors = new int[N - 1];
            for (int i = 0; i < N + 1; i++) adjColors[i] = new List<int>();
            var count = new int[N + 1];
            for (int i = 0; i < N - 1; i++)
            {
                for (int c = colorMax - Math.Max(count[a[i]], count[b[i]]); c > 0; c--)
                {
                    if (!adjColors[a[i]].Contains(c) && !adjColors[b[i]].Contains(c))
                    {
                        colors[i] = c;
                        adjColors[a[i]].Add(c);
                        adjColors[b[i]].Add(c);
                        count[a[i]] += 1;
                        count[b[i]] += 1;
                        break;
                    }
                }
            }
            Console.WriteLine(colorMax);
            foreach (int c in colors) Console.WriteLine(c);
        }
    }
}
