using System;

namespace A___Harmony
{
    class Program
    {
        static void Main(string[] args)
        {
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            if (((AB[0] + AB[1]) % 2) == 1)
            {
                Console.WriteLine("IMPOSSIBLE");
            }
            else
            {
                Console.WriteLine((AB[0] + AB[1]) / 2);
            }
        }
    }
}
