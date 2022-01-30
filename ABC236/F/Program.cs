using System;
using System.Linq;

namespace F
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var c = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = long.MaxValue;
            for (int choice = 1; choice < (1 << N); choice++)
            {
                var hot = new bool[1 << N];
                hot[0] = true;
                for (int i = 1; i < (1 << N); i++) hot[i] = false;
                for (int bit = 0; bit < N; bit++)
                {
                    if (((choice & (1 << bit)) == 0)) continue;
                    for (int i = hot.Length - 1; i >= 0; i--)
                        if ((i + (1 << bit)) < hot.Length && hot[i]) hot[i + (1 << bit)] = true;
                }
                if (hot.Count(b => !b) > 0)
                    continue;
                Console.WriteLine(choice);
            }
        }
    }
}
