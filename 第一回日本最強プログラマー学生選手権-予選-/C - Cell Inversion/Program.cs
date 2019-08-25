using System;
using System.Linq;

namespace C___Cell_Inversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            long MOD = 1000000007;

            if (S[0] == 'W' || S[S.Length - 1] == 'W') return 0;
            var isRight = new bool[S.Length];
            for (int i = 0; i < S.Length; i++) isRight[i] = (i % 2 == 1) == (S[i] == 'W');
            if (isRight.Count(b => b) != S.Length / 2) return 0;

            long setCount = 1;
            int rightCount = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (rightCount < 0) return 0;
                if (isRight[i])
                {
                    rightCount++;
                }
                else
                {
                    setCount = setCount * rightCount % MOD;
                    rightCount--;
                }
            }
            for (int i = 2; i <= N; i++) setCount = setCount * i % MOD;
            return setCount;
        }
    }
}
