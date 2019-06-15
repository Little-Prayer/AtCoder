using System;

namespace D___Squirrel_Merchant
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var exchangeA = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var exchangeB = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
        }
    }
}
