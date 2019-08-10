using System;
using System.Linq;

namespace C___Green_Bin
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var strs = new string[N];
            for (int i = 0; i < N; i++)
            {
                var str = Console.ReadLine();
                strs[i] = str;
            }
            strs = strs.OrderBy(s => s).ToArray();
            long result = 0;
            long count = 1;
            for (int i = 1; i < N; i++)
            {
                if (strs[i] == strs[i - 1])
                {
                    count++;
                }
                else
                {
                    result += count * (count - 1) / 2;
                    count = 1;
                }
            }
            result += count * (count - 1) / 2;
            Console.WriteLine(result);
        }
    }
}
