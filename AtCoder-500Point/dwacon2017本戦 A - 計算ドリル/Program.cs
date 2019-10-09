using System;

namespace dwacon2017本戦_A___計算ドリル
{
    class Program
    {
        static int[,,,] DP;
        static bool[,,,] Complete;
        static string S;
        static void Main(string[] args)
        {
            var K = int.Parse(Console.ReadLine());
            S = Console.ReadLine();
            var L = S.Length;
            DP = new int[L, L, L + 1, 2];
            Complete = new bool[L, L, L + 1, 2];
            for (int i = 0; i < L; i++)
                for (int j = 0; j < L; j++)
                    for (int k = 0; k < L; k++)
                        for (int l = 0; l < 2; l++)
                        {
                            DP[i, j, k, l] = l == 1 ? int.MinValue : int.MaxValue;
                            Complete[i, j, k, l] = false;
                        }
            Console.WriteLine(rec(0, L - 1, K, 1) != int.MinValue ? $"OK\n{DP[0, L - 1, K, 1]}" : "NG");
        }
        static int rec(int start, int end, int change, int isMax)
        {
            if (Complete[start, end, change, isMax]) return DP[start, end, change, isMax];
            Complete[start, end, change, isMax] = true;

            if ((end - start + 1) % 2 == 0) return isMax > 0 ? int.MinValue : int.MaxValue;

            if (end - start + 1 < change) return DP[start, end, change, isMax] = rec(start, end, change - 1, isMax);

            if (start == end)
            {
                if (change > 0) return DP[start, end, change, isMax] = isMax > 0 ? 9 : 0;
                if (S[start] >= '0' && S[start] <= '9') return DP[start, end, change, isMax] = int.Parse(S[start].ToString());
                return DP[start, end, change, isMax] = isMax > 0 ? int.MinValue : int.MaxValue;
            }

            if (change == 0 && S[end] != '+' && S[end] != '-') return DP[start, end, change, isMax] = isMax > 0 ? int.MinValue : int.MaxValue;

            var result = isMax > 0 ? int.MinValue : int.MaxValue;
            var cMinus = change - (S[end] == '-' ? 0 : 1); var cPlus = change - (S[end] == '+' ? 0 : 1);

            if (isMax > 0)
            {
                for (int split = start; split < end - 1; split++)
                {
                    for (int c = 0; c <= cPlus; c++)
                    {
                        var left = rec(start, split, c, 1);
                        var right = rec(split + 1, end - 1, cPlus - c, 1);
                        if (left != int.MinValue && right != int.MinValue) result = Math.Max(result, left + right);
                    }
                    for (int c = 0; c <= cMinus; c++)
                    {
                        var left = rec(start, split, c, 1);
                        var right = rec(split + 1, end - 1, cMinus - c, 0);
                        if (left != int.MinValue && right != int.MaxValue) result = Math.Max(result, left - right);
                    }
                }
            }
            else
            {
                for (int split = start; split < end - 1; split++)
                {
                    for (int c = 0; c <= cPlus; c++)
                    {
                        var left = rec(start, split, c, 0);
                        var right = rec(split + 1, end - 1, cPlus - c, 0);
                        if (left != int.MaxValue && right != int.MaxValue) result = Math.Min(result, left + right);
                    }
                    for (int c = 0; c <= cMinus; c++)
                    {
                        var left = rec(start, split, c, 0);
                        var right = rec(split + 1, end - 1, cMinus - c, 1);
                        if (left != int.MaxValue && right != int.MinValue) result = Math.Min(result, left - right);
                    }
                }
            }
            return DP[start, end, change, isMax] = result;
        }
    }
}
