using System;
using System.Linq;

namespace _025___Digit_Product_Equation_7_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
            int solver()
            {
                var NB = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                var N = NB[0]; var B = NB[1];

                if (N < B) return 0;

                var result = 0;

                dfs("", 0);
                void dfs(in string current, int last)
                {
                    for (int i = last; i <= 9; i++)
                    {
                        var next = current + i.ToString();
                        if (next.Length == 12 || long.Parse(next) > N) continue;
                        var check = next.
                        Select(c => long.Parse(c.ToString())).
                        Aggregate(1L, (n, aggre) => n * aggre) + B;
                        if (next.
                                    OrderBy(c => c).
                                    SequenceEqual(check.
                                    ToString().
                                    OrderBy(c => c)) && check <= N)
                            result++;

                        dfs(next, i);
                    }
                }
                return result;
            }
        }


    }
}
