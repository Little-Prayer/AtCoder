using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var result = -1;
            for (int i = 1; i <= 50000; i++) if ((int)(i * 1.08) == N) result = i;
            Console.WriteLine(result != -1 ? result.ToString() : ":(");
        }
    }
}
