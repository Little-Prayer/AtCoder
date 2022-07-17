using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            Console.WriteLine(2 * N);
            var result = (N % 4) > 0 ? (N % 4).ToString() : "";
            while (N >= 4)
            {
                result += "4";
                N -= 4;
            }
            Console.WriteLine(result);
        }
    }
}
