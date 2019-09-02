using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = ab[0]; var B = ab[1];
            var count = 1;
            while (A + (count - 1) * (A - 1) < B) count++;
            Console.WriteLine(B == 1 ? 0 : count);
        }
    }
}
