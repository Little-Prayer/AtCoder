using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            double result = (int)((N + 1) / 2);
            result /= N;
            Console.WriteLine(result);
        }
    }
}
