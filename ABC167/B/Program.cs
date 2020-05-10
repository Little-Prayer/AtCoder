using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABCK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var A = ABCK[0]; var B = ABCK[1]; var C = ABCK[2]; var K = ABCK[3];
            if ((A + B) >= K) Console.WriteLine(Math.Min(A, K));
            else Console.WriteLine(A - (K - (A + B)));
        }
    }
}
