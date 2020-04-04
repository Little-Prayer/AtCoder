using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NK[0]; var K = NK[1];

            var mod = N % K;
            Console.WriteLine(Math.Min(mod, Math.Abs(K - mod)));
        }
    }
}
