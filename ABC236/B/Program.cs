using System;


namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var check = new int[N + 1];
            for (int i = 1; i < N + 1; i++) check[i] = 4;
            for (int i = 0; i < A.Length; i++) check[A[i]]--;

            for (int i = 1; i < N + 1; i++)
                if (check[i] == 1)
                    Console.WriteLine(i);


        }
    }
}
