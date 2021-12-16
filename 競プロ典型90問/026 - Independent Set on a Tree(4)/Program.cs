using System;
using System.Collections.Generic;
using System.Linq;
namespace _026___Independent_Set_on_a_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var tree = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) tree[i] = new List<int>();

            for (int i = 0; i < N - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                tree[ab[0]].Add(ab[1]);
                tree[ab[1]].Add(ab[0]);
            }

            var seen = new bool[N + 1];
            var divide = new bool[N + 1];
            dfs(1, true);

            void dfs(int current, bool div)
            {
                if (seen[current]) return;
                seen[current] = true;
                divide[current] = div;
                foreach (int next in tree[current]) dfs(next, !div);
            }
            int[] result;
            if (divide.Count(b => b) >= N / 2)
                result = divide.Select((b, i) => (b, i)).Where(x => x.b).Take(N / 2).Select(x => x.i).ToArray();
            else result = divide.Select((b, i) => (b, i)).Where(x => !x.b).Skip(1).Take(N / 2).Select(x => x.i).ToArray();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
