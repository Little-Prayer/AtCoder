using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();

            var result = 0;

            for (int d1 = 0; d1 <= 9; d1++)
            {
                for (int d2 = 0; d2 <= 9; d2++)
                {
                    for (int d3 = 0; d3 <= 9; d3++)
                    {
                        var i1 = S.IndexOf(d1.ToString(), 0);
                        var i2 = S.IndexOf(d2.ToString(), i1 + 1);
                        var i3 = S.IndexOf(d3.ToString(), i2 + 1);

                        if (i1 >= 0 && i2 >= 0 && i3 >= 0) result++;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
