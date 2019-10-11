using System;

namespace JSC2019決勝_B___Reachability
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solve());
        }
        static string solve()
        {
            var N = int.Parse(Console.ReadLine());
            var xy = new bool[N + 1, N + 1];
            for (int i = 0; i < N; i++)
            {
                var a = Console.ReadLine();
                for (int j = 0; j < N; j++) if (a[j] == '1') xy[i + 1, j + 1] = true;
            }

            var xz = new bool[N + 1, N + 1];
            for (int i = 0; i < N; i++)
            {
                var b = Console.ReadLine();
                for (int j = 0; j < N; j++) if (b[j] == '1') xz[i + 1, j + 1] = true;
            }

            var yz = new bool[N + 1, N + 1];
            for (int i = 0; i < N + 1; i++) for (int j = 0; j < N + 1; j++) yz[i, j] = true;
            for (int x = 1; x < N + 1; x++)
            {
                for (int y = 1; y < N + 1; y++)
                {
                    for (int z = 1; z < N + 1; z++)
                    {
                        if (xy[x, y]) yz[y, z] = yz[y, z] & xz[x, z];
                    }
                }
            }

            for (int x = 1; x < N + 1; x++)
            {
                for (int z = 1; z < N + 1; z++)
                {
                    if (!xz[x, z]) continue;
                    var existPath = false;
                    for (int y = 1; y < N + 1; y++)
                    {
                        if (xy[x, y] & yz[y, z]) existPath = true;
                    }
                    if (!existPath) return "-1";
                }
            }

            var result = new System.Text.StringBuilder();
            for (int y = 1; y < N + 1; y++)
            {
                for (int z = 1; z < N + 1; z++)
                {
                    result.Append(yz[y, z] ? '1' : '0');
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
