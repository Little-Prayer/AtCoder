using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            long result = 1;
            for(int i = 0;i<N;i++)
            {
                result *=2;
            }
            Console.WriteLine(result);
        }
    }
}
