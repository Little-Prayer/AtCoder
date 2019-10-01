using System;

namespace エクサウィーズ2019_C___Snuke_the_Wizard
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NQ[0]; var Q = NQ[1];
            var s = Console.ReadLine();
            var t = new char[Q]; var d = new char[Q];
            for (int i = 0; i < Q; i++)
            {
                var td = Console.ReadLine();
                t[i] = td[0];
                d[i] = td[2];
            }

            var deadL = -1; var deadR = N;
            for (int i = Q - 1; i >= 0; i--)
            {
                if (d[i] == 'L')
                {
                    if (deadL < N - 1 && s[deadL + 1] == t[i]) deadL++;
                    if (deadR < N && s[deadR] == t[i]) deadR++;
                }
                else
                {
                    if (deadL > -1 && s[deadL] == t[i]) deadL--;
                    if (deadR > 0 && s[deadR - 1] == t[i]) deadR--;
                }
            }

            Console.WriteLine(Math.Max(deadR - deadL - 1, 0));
        }
    }
}