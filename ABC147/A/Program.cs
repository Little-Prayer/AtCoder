using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(A[0] + A[1] + A[2] < 22 ? "win" : "bust");
        }
    }
}
