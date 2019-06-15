using System;

namespace A___Ball_Distribution
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var K = read[1];
            if(K!=1)Console.WriteLine(N-K);
            else Console.WriteLine(0);
        }
    }
}
