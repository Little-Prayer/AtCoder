using System;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var NL = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NL[0]; var L = NL[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var last = 0;
            foreach (int p in A)
            {
                if (p == 1)
                {
                    if (last + 2 <= L) { last += 2; }
                }
                else
                {
                    if (last + 3 <= L)
                    {
                        last += 3;
                    }
                    else if (last + 2 == L)
                    {
                        last += 2;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
