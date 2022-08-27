using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var result = N % 998244353;
            if (result < 0) result += 998244353;
            Console.WriteLine(result);
        }
    }
}
