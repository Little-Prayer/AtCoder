using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }

        static string solver()
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var S = new string[N];
            for (int i = 0; i < N; i++) S[i] = Console.ReadLine();
            var allLength = S.Sum(s => S.Length);
            var T = new string[M];
            for (int i = 0; i < M; i++) T[i] = Console.ReadLine();
            Array.Sort(T);

            var Sdash = Enumerate(S).ToArray();
            var candidate = new List<string>();
            foreach (string[] s in Sdash)
            {

            }

        }

        static List<int> distribution(int n, int k)
        {
            (int, int, List<int>) subdis(int n, int k, List<int> lis)
            {
                if (k > 0)
                {
                    for (int i = 1; i < n - k; i++)
                    {
                        lis.Add(i);
                        return (n - i, k - 1, lis);
                    }
                }
                lis.Add(1);
                return (0, 0, lis);
            }
            var lis = new List<int>();
        }
        static bool search(string s, string[] target)
        {
            int min = 0;
            int max = target.Length - 1;

            while (max >= min)
            {
                int mid = min + (max - min) / 2;
                if (target[mid] == s) return true;
                else if (target[mid].CompareTo(s) < 0) max = mid - 1;
                else if (target[mid].CompareTo(s) > 0) min = mid + 1;
            }
            return false;
        }
        public static IEnumerable<T[]> Enumerate<T>(IEnumerable<T> items)
        {
            if (items.Count() == 1)
            {
                yield return new T[] { items.First() };
                yield break;
            }
            foreach (var item in items)
            {
                var leftside = new T[] { item };
                var unused = items.Except(leftside);
                foreach (var rightside in Enumerate(unused))
                {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }
    }
}
