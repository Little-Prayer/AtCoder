using System;

namespace C___City_Savers
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var Bi = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long result = 0;
            for (int i = 0; i < N; i++)
            {
                if (Ai[i] >= Bi[i])
                {
                    result += Bi[i];
                }
                else
                {
                    result += Ai[i];
                    long overkill = Bi[i] - Ai[i];
                    if (Ai[i + 1] >= overkill)
                    {
                        result += overkill;
                        Ai[i + 1] -= overkill;
                    }
                    else
                    {
                        result += Ai[i + 1];
                        Ai[i + 1] = 0;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
