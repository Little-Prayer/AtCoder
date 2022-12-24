using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var K = int.Parse(Console.ReadLine());
            var result = "";
            for (int i = 0; i < K; i++)
            {
                result += (char)('A' + i);
            }
            Console.WriteLine(result);

        }
    }
}
