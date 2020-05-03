using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var hasTreat = new bool[N + 1];
            for (int i = 0; i < K; i++)
            {
                var d = int.Parse(Console.ReadLine());
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                foreach (int n in read)
                {
                    hasTreat[n] = true;
                }
            }
            var result = 0;
            foreach (bool b in hasTreat)
            {
                if (!b) result++;
            }
            Console.WriteLine(result - 1);
        }
    }
}
