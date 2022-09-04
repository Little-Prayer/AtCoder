using System;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = new int[1];
            A = A.Concat(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse)).ToArray();
            var count = 0;
            System.Text.StringBuilder output = new System.Text.StringBuilder();

            void swap(int a, int b)
            {
                var temp = A[a];
                A[a] = A[b];
                A[b] = temp;
            }
            void longswap(int a, int b)
            {
                if (a > b)
                {
                    longswap(b, a);
                    return;
                }
                for (int i = a; i < b; i += 2)
                {
                    if (i + 2 > N) break;
                    output.AppendLine($"B {i}");
                    swap(i, i + 2);
                    count++;
                }
            }
            for (int i = N; i >= 1; i--)
            {
                if ((Math.Abs(A[i] - i)) % 2 == 1) continue;
                for (int j = i - 2; j >= 1; j -= 2)
                {
                    if ((Math.Abs(A[j] - j)) % 2 == 1)
                    {
                        longswap(j, i);
                        break;
                    }
                }
            }
            for (int i = N; i > 0; i -= 2)
            {
                if (((Math.Abs(A[i] - i)) % 2 == 1) && (Math.Abs(A[i - 1] - (i - 1))) % 2 == 1)
                {
                    swap(i - 1, i);
                    output.AppendLine($"A {i - 1}");
                    count++;
                }
            }

            int search(int number)
            {
                var result = 0;
                for (int i = 1; i <= N; i++)
                {
                    if (A[i] == number)
                    {
                        result = i;
                        break;
                    }
                }
                return result;
            }
            for (int i = N; i > 0; i--)
            {
                if (A[i] != i) longswap(i, search(i));
            }

            Console.WriteLine(count);
            Console.WriteLine(output.ToString());
        }
    }
}
