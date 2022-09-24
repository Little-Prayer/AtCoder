using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = AB[0]; var B = AB[1];

            Console.WriteLine(A | B);
        }
    }
}
