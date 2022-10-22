using System;


namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var nxy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = nxy[0]; var x = nxy[1]; var y = nxy[2];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var DPx = new bool[40001, N + 1];
            var DPy = new bool[40001, N + 1];
            DPx[A[0] + 20000, 1] = true;
            DPy[20000, 1] = true;
            for (int i = 2; i <= N; i++)
            {
                if ((i % 2) == 1)
                {
                    for (int j = 0; j < 40001; j++)
                    {
                        DPy[j, i] = DPy[j, i - 1];
                        if (j - A[i - 1] >= 0 && DPx[j - A[i - 1], i - 1]) DPx[j, i] = true;
                        if (j + A[i - 1] < 40001 && DPx[j + A[i - 1], i - 1]) DPx[j, i] = true;
                    }
                }
                else
                {
                    for (int j = 0; j < 40001; j++)
                    {
                        DPx[j, i] = DPx[j, i - 1];
                        if (j - A[i - 1] >= 0 && DPy[j - A[i - 1], i - 1]) DPy[j, i] = true;
                        if (j + A[i - 1] < 40001 && DPy[j + A[i - 1], i - 1]) DPy[j, i] = true;
                    }
                }
            }
            Console.WriteLine((DPx[x + 20000, N] && DPy[y + 20000, N]) ? "Yes" : "No");
        }
    }
}
