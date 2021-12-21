using System;
using System.Linq;

namespace _031___VS_AtCoder_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            var grundy = new int[51, 3001];

            for (int w = 0; w <= 50; w++)
            {
                for (int b = 0; b <= 2000; b++)
                {
                    var mex = new bool[2000];
                    if (b >= 2) for (int i = 1; i <= b / 2; i++) mex[grundy[w, b - i]] = true;
                    if (w >= 1) mex[grundy[w - 1, b + w]] = true;
                    for (int x = 0; x < 2000; x++)
                    {
                        if (mex[x]) continue;
                        grundy[w, b] = x;
                        break;
                    }
                }
            }
            var N = int.Parse(Console.ReadLine());
            var W = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = 0;
            for (int i = 0; i < N; i++)
            {
                if (i == N - 1) i += 0;
                result ^= grundy[W[i], B[i]];
            }
            Console.WriteLine(result == 0 ? "Second" : "First");
        }
    }
}
