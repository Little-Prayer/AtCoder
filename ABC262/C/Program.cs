using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var listA = new List<int>();
            listA.Add(0);
            foreach (int i in A) listA.Add(i);

            var count = 0L;
            for (int i = 1; i <= N; i++) if (listA[i] == i) count++;
            count = count * (count - 1) / 2;

            for (int i = 1; i <= N; i++)
            {
                if (listA[i] > i && listA[listA[i]] == i) count++;
            }
            Console.WriteLine(count);
        }
    }
}
