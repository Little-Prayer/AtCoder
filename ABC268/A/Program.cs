using System;
using System.Collections.Generic;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var abcde = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var result = new Dictionary<int, int>();
            foreach (int i in abcde)
            {
                if (!result.ContainsKey(i)) result.Add(i, 0);
            }
            Console.WriteLine(result.Keys.Count);
        }
    }
}
