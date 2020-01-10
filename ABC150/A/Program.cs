using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var KX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(KX[0] * 500 >= KX[1] ? "Yes" : "No");
        }
    }
}
