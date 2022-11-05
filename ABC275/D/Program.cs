using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var dic = new Dictionary<long, long>();
            dic.Add(0, 1);

            long recur(long num)
            {
                if (dic.ContainsKey(num)) return dic[num];
                long result = recur(num / 2) + recur(num / 3);
                dic.Add(num, result);
                return result;
            }
            Console.WriteLine(recur(N));
        }
    }
}
