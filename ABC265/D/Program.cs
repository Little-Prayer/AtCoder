using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var NPQR = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NPQR[0]; var P = NPQR[1]; var Q = NPQR[2]; var R = NPQR[3];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var accum = new long[N + 1];
            for (int i = 0; i < N; i++) accum[i + 1] = accum[i] + A[i];

            var x = 0;
            var w = 3;
            while (w <= N)
            {

                if (accum[w] - accum[x] < P + Q + R)
                {
                    w++;
                    continue;
                }
                if (accum[w] - accum[x] > P + Q + R)
                {
                    x++;
                    continue;
                }
                var y = x + 1;
                while (y < w)
                {
                    if (accum[y] - accum[x] < P)
                    {
                        y++;
                        continue;
                    }
                    if (accum[y] - accum[x] > P)
                    {
                        x++;
                        break;
                    }
                    var z = y + 1;
                    while (z < w)
                    {
                        if (accum[z] - accum[y] < Q)
                        {
                            z++;
                            continue;
                        }
                        if (accum[z] - accum[y] > Q)
                        {
                            break;
                        }
                        if (accum[w] - accum[z] == R) return true;
                        else break;
                    }
                    x++;
                }
            }
            return false;
        }
    }
}
