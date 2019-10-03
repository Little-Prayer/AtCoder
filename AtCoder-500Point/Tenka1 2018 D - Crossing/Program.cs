using System;
using System.Collections.Generic;
using System.Text;

namespace Tenka1_2018_D___Crossing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solve());
        }
        static string solve()
        {
            var N = int.Parse(Console.ReadLine());
            var len = 1;
            while (true)
            {
                if (2 * N == len * (len + 1)) break;
                if (2 * N < len * (len + 1)) return "No";
                len++;
            }

            var sets = new List<int>[len + 1];
            for (int i = 0; i < len + 1; i++)
            {
                sets[i] = new List<int>();
                sets[i].Add(len);
            }
            var n = 1;
            for (int i = 0; i < len + 1; i++)
            {
                for (int j = i + 1; j < len + 1; j++)
                {
                    sets[i].Add(n);
                    sets[j].Add(n);
                    n++;
                }
            }

            var result = new StringBuilder();
            result.AppendLine("Yes");
            result.AppendLine((len + 1).ToString());
            foreach (List<int> s in sets)
            {
                result.AppendLine(string.Join(" ", s));
            }
            return result.ToString();
        }
    }
}