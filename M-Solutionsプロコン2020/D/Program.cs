using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var market = new List<int>();
            market.Add(A[0]);
            for (int i = 1; i < N; i++)
            {
                if (A[i] == A[i - 1]) continue;
                market.Add(A[i]);
            }

            if (market.Count <= 1) return 1000;

            var infection = new List<int>();
            if (market[0] < market[1]) infection.Add(market[0]);
            for (int i = 1; i < market.Count - 1; i++)
            {
                if (((market[i] > market[i - 1]) && (market[i] > market[i + 1])) || ((market[i] < market[i - 1]) && (market[i] < market[i + 1])))
                {
                    infection.Add(market[i]);
                }
            }
            if (market[market.Count - 1] > market[market.Count - 2]) infection.Add(market[market.Count - 1]);

            if (infection.Count == 0) return 1000;

            long money = 1000;
            long stock = 0;
            for (int i = 0; i + 1 < infection.Count; i += 2)
            {
                long purchase = money / infection[i];
                money -= purchase * infection[i];
                stock += purchase;

                money += stock * infection[i + 1];
                stock = 0;
            }
            return money;
        }
    }
}
