using System;

namespace B別解
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var d = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var dSum = 0;
            foreach (int i in d) dSum += i;

            var result = 0;
            foreach (int i in d)
            {
                dSum -= i;
                result += dSum * i;
            }
            Console.WriteLine(result);
        }
    }
}
