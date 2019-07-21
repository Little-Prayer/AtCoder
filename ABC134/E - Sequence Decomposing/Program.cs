using System;
using System.Collections.Generic;

namespace E___Sequence_Decomposing
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var colors = new List<int>();
            colors.Add(-1);

            for (int i = 0; i < N; i++)
            {
                var Ai = int.Parse(Console.ReadLine());
                var updateIndex = colors[colors.Count - 1] != Ai ? binarySearch(colors, Ai) : -1;
                if (updateIndex >= 0)
                {
                    colors[updateIndex] = Ai;
                }
                else
                {
                    colors.Add(Ai);
                }
            }
            Console.WriteLine(colors.Count);
        }
        static int binarySearch(List<int> list, int number)
        {
            var left = -1;
            var right = list.Count;
            while (right - left > 1)
            {
                int mid = (left + right) / 2;
                if (list[mid] <= number)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }
            if (right > list.Count - 1) return -1;

            return right;
        }
    }
}
