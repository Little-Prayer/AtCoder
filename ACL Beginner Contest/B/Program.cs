using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABCD = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            if (ABCD[0] > ABCD[3] || ABCD[1] < ABCD[2]) Console.WriteLine("No");
            else Console.WriteLine("Yes");
        }
    }
}
