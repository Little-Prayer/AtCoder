using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var remainBricks = 0;
            for (int i = 0; i < N; i++) if (a[i] == remainBricks + 1) remainBricks++;
            Console.WriteLine(remainBricks == 0 ? -1 : N - remainBricks);
        }
    }
}
