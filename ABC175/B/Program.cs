using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var Li = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Array.Sort(Li);
            var count = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    for (int k = j + 1; k < N; k++)
                    {
                        if ((Li[i] + Li[j] > Li[k]) && ((Li[i] != Li[j]) && (Li[j] != Li[k]))) count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
