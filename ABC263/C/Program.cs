using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];

            var test = new List<int>();
            test.Add(1);
            test.Add(2);
            IEnumerable<List<int>> nextList(List<int> start)
            {
                yield return start;
                for (int i = start.Count - 1; i >= 0; i--)
                {
                    if (start[i] < M - (start.Count - 1 - i))
                    {
                        start[i]++;
                        for (int j = i + 1; j < start.Count; j++)
                        {
                            start[j] = start[j - 1] + 1;
                        }
                        yield return start;
                    }
                }
            }
            foreach (var lis in nextList(test))
            {
                string.Join(" ", lis);
            }
        }
    }
}
