using System;

namespace B___Resistors_in_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            double result = 0;
            foreach (int i in Ai) result += (double)(1 / (double)i);
            Console.WriteLine(1 / result);
        }
    }
}
