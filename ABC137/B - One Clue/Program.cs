using System;

namespace B___One_Clue
{
    class Program
    {
        static void Main(string[] args)
        {
            var kx = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var result = new int[2 * kx[0] - 1];
            for (int i = 0; i < 2 * kx[0] - 1; i++) result[i] = kx[1] - kx[0] + 1 + i;
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
