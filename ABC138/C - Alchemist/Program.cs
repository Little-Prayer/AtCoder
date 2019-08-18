using System;
using System.Linq;

namespace C___Alchemist
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var vi = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            vi = vi.OrderBy(v => v).ToArray();
            double result = (vi[0] + vi[1]) / 2.0;
            for (int i = 2; i < N; i++) result = (result + vi[i]) / 2.0;
            Console.WriteLine(result);
        }
    }
}
