using System;
using System.Collections.Generic;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var dic = new Dictionary<string, int>();
            for (int i = 0; i < N; i++)
            {
                var read = Console.ReadLine();
                if (dic.ContainsKey(read))
                {
                    Console.WriteLine($"{read}({dic[read]})");
                    dic[read] += 1;
                }
                else
                {
                    dic.Add(read, 1);
                    Console.WriteLine(read);
                }
            }
        }
    }
}
