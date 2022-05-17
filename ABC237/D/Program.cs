using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();

            var A = new int[N + 1];
            for (int i = 0; i < N + 1; i++) A[i] = N;
            var max = N; var min = 0;
            for (int i = 0; i < N; i++)
            {
                if (S[i] == 'L')
                {
                    A[max] = i;
                    max--;
                }
                else
                {
                    A[min] = i;
                    min++;
                }
            }
            Console.WriteLine(string.Join(" ", A));
        }
    }
}
