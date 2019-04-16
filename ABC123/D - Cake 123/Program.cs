using System;
using System.Linq;

namespace D___Cake_123
{
    class Program
    {
        static void Main(string[] args)
        {
            var K = int.Parse(Console.ReadLine().Split(' ')[3]);
            var cakesA = Console.ReadLine().Split(' ').Select(s => long.Parse(s)).OrderByDescending(s=>s).ToArray();
            var cakesB = Console.ReadLine().Split(' ').Select(s => long.Parse(s)).OrderByDescending(s=>s).ToArray();
            var cakesC = Console.ReadLine().Split(' ').Select(s => long.Parse(s)).OrderByDescending(s=>s).ToArray();

            var tastes = new long[K];

            var numberA = 0;
            var numberB = 0;
            var numberC = 0;

            for(long i=0;i<K;i++)
            {
                tastes[i] = cakesA[numberA]+cakesB[numberB]+cakesC[numberC];

            }
        }

        static long offsetArray(long[] array,int i)
        {
            if(i+1 == array.Length)
            {
                return 10_000_000_000;
            }else{
                return array[i] - array[i+1];
            }
        }
    }
}
