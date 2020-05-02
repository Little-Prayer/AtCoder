using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = long.Parse(Console.ReadLine());
            var result = 0;
            var amount = 100L;
            while (amount < X)
            {
                amount += amount / 100;
                result++;
            }
            Console.WriteLine(result);
        }
    }
}
