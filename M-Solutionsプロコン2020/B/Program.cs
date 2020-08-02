using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = ABC[0]; var B = ABC[1]; var C = ABC[2];
            var K = int.Parse(Console.ReadLine());

            var count = 0;
            while (A >= B)
            {
                count++;
                B *= 2;
            }
            while (B >= C)
            {
                count++;
                C *= 2;
            }
            Console.WriteLine(K >= count ? "Yes" : "No");
        }
    }
}
