using System;

namespace A___Apple_Pie
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var A = read[0];
            var P = read[1];

            int pie = (3*A + P) / 2;
            Console.WriteLine(pie);
        }
    }
}
