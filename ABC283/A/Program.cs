using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var A = AB[0]; var B = AB[1];
            long result = 1;

            for (int i = 0; i < B; i++)
            {
                result *= A;
            }
            Console.WriteLine(result);
        }
    }
}
