using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var X = long.Parse(Console.ReadLine());


            IEnumerable<long> factory(int start, int digits)
            {
                for (int dif = -9; dif <= 9; dif++)
                {
                    var result = new System.Text.StringBuilder(start.ToString());
                    var current = start;
                    while (result.Length < digits)
                    {
                        current += dif;
                        if (current < 0 || current >= 10) break;
                        result.Append(current.ToString());
                    }
                    if (result.Length < digits) continue;
                    yield return long.Parse(result.ToString());
                }
            }
            long res = 0;
            int sta = int.Parse(X.ToString()[0].ToString());
            int dig = X.ToString().Length;
            while (res < X)
            {
                foreach (long l in factory(sta, dig))
                {
                    if (l >= X)
                    {
                        res = l;
                        break;
                    }
                }
                if (sta != 9) sta++;
                {
                    sta = 1;
                    dig++;
                }
            }
            Console.WriteLine(res);
        }
    }
}
