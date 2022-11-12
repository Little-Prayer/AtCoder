using System;
using System.Collections.Generic;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var N = int.Parse(Console.ReadLine());
            var dic = new Dictionary<string, int>();
            var first = new char[] { 'H', 'D', 'C', 'S' };
            var second = new char[] { 'A', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K' };

            for (int i = 0; i < N; i++)
            {
                var read = Console.ReadLine();
                if (dic.ContainsKey(read)) return false;
                dic.Add(read, 0);
                if (!first.Contains(read[0])) return false;
                if (!second.Contains(read[1])) return false;
            }
            return true;
        }
    }
}
