using System;

namespace ARC061_C___たくさんの数式
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var N = S.Length;
            var A = new int[N];
            for (int i = 0; i < N; i++) A[i] = int.Parse(S[i].ToString());

            long result = 0;
            for (int i = 0; i < (1 << (N - 1)); i++)
            {
                long subtotal = 0;
                long current = A[0];
                for (int j = 1; j < N; j++)
                {
                    if ((i & (1 << (j - 1))) > 0)
                    {
                        subtotal += current;
                        current = A[j];
                    }
                    else
                    {
                        current = current * 10 + A[j];
                    }
                }
                subtotal += current;
                result += subtotal;
            }
            Console.WriteLine(result);
        }

    }
}
