using System;

namespace C___Divide_the_Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var di = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Array.Sort(di);
            Console.WriteLine(di[N / 2] - di[N / 2 - 1]);
        }
    }
}
