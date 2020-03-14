using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine().Replace('?', '.');
            var b = Console.ReadLine().Replace('?', '.');
            var c = Console.ReadLine().Replace('?', '.');
            var abc = merge(merge(a, b), c).Length;
            var acb = merge(merge(a, c), b).Length;
            var bac = merge(merge(b, a), c).Length;
            var bca = merge(merge(b, c), a).Length;
            var cab = merge(merge(c, a), b).Length;
            var cba = merge(merge(c, b), a).Length;
            Console.WriteLine(Math.Min(Math.Min(Math.Min(abc, acb), Math.Min(bca, bac)), Math.Min(cab, cba)));
        }

        static string merge(string a, string b)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(a, b)) return a;
            if (System.Text.RegularExpressions.Regex.IsMatch(b, a)) return b;

            int start = Math.Max(a.Length - b.Length, 0);
            bool Check = false;
            for (; start < a.Length; start++)
            {
                Check = true;
                for (int c = 0; c < Math.Min(b.Length, a.Length - start); c++)
                {
                    if (a[start + c] != b[c] && a[start + c] != '.' && b[c] != '.')
                    {
                        Check = false;
                        break;
                    }
                }
                if (Check) break;
            }
            if (!Check) return a + b;
            return a + b.Substring(a.Length - start);
        }
    }
}
