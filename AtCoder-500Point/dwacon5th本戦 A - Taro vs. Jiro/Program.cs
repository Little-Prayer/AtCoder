using System;
using System.Collections.Generic;
using System.Linq;

namespace dwacon5th本戦_A___Taro_vs._Jiro
{
    class Program
    {
        static void Main(string[] args)
        {
            var NMK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = (int)NMK[0]; var M = (int)NMK[1]; var K = NMK[2];
            var s = Console.ReadLine();
            var connection = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connection[i] = new List<int>();
            for (int i = 0; i < M; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[ab[0]].Add(ab[1]);
                connection[ab[1]].Add(ab[0]);
            }
            var winner = new int[N + 1];
            for (int i = 1; i < N + 1; i++)
            {
                if (connection[i].Count(n => s[n - 1] == 'B') == connection[i].Count) winner[i] = 1;
                else if (connection[i].Count(n => s[n - 1] == 'R') == connection[i].Count) winner[i] = -1;
                else winner[i] = 0;
            }

            if (K % 2 == 1)
            {
                for (int i = 1; i < N + 1; i++)
                {
                    Console.WriteLine(winner[i] == -1 ? "Second" : "First");
                }
            }
            else
            {
                for (int i = 1; i < N + 1; i++)
                {
                    var isSecondWin = true;
                    foreach (int e in connection[i])
                    {
                        if (winner[e] == 1) isSecondWin = false;
                    }
                    Console.WriteLine(isSecondWin ? "Second" : "First");
                }
            }
        }
    }
}
