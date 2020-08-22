using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var max = 0L;
            var result = 0L;
            foreach (int a in A)
            {
                if (max < a) max = a;
                else result += max - a;
            }
            Console.WriteLine(result);
        }
    }
}
