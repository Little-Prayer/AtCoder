using System;
using System.Collections.Generic;
namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMT = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NMT[0]; var M = NMT[1]; var T = NMT[2];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var bonus = new Dictionary<int, long>();

            for (int i = 0; i < M; i++)
            {
                var xy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                bonus.Add(xy[0], xy[1]);
            }

            var result = true;
            for (int i = 1; i < N; i++)
            {
                if (bonus.ContainsKey(i)) T += bonus[i];

                T -= A[i - 1];
                if (T <= 0)
                {
                    result = false;
                    break;
                }
            }
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
