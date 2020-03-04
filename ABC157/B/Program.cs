using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var A = new int[3, 3];
            var isHit = new bool[3, 3];
            for (int i = 0; i < 3; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < 3; j++)
                {
                    A[i, j] = read[j];
                    isHit[i, j] = false;
                }

            }
            var N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                var read = int.Parse(Console.ReadLine());
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (A[j, k] == read) isHit[j, k] = true;
                    }
                }
            }

            for (int h = 0; h < 3; h++)
            {
                var result = true;
                for (int v = 0; v < 3; v++)
                {
                    if (!isHit[h, v])
                    {
                        result = false;
                        break;
                    }
                }
                if (result) return true;
            }
            for (int v = 0; v < 3; v++)
            {
                var result = true;
                for (int h = 0; h < 3; h++)
                {
                    if (!isHit[h, v])
                    {
                        result = false;
                        break;
                    }
                }
                if (result) return true;
            }
            if (isHit[0, 0] && isHit[1, 1] && isHit[2, 2]) return true;
            if (isHit[2, 0] && isHit[1, 1] && isHit[0, 2]) return true;
            return false;
        }
    }
}
