using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var ST = Console.ReadLine().Split(' ');
            var S = ST[0]; var T = ST[1];
            var AB = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = AB[0]; var B = AB[1];
            var U = Console.ReadLine();

            if (S == U) A -= 1;
            else B -= 1;
            Console.WriteLine($"{A} {B}");
        }
    }
}
