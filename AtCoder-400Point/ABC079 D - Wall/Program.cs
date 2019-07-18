using System;

namespace ABC079_D___Wall
{
    class Program
    {
        static void Main(string[] args)
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var changeCosts = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < 10; j++) changeCosts[i, j] = read[j];
            }

            for (int via = 0; via < 10; via++)
                for (int from = 0; from < 10; from++)
                    for (int to = 0; to < 10; to++)
                        changeCosts[from, to] = Math.Min(changeCosts[from, to], changeCosts[from, via] + changeCosts[via, to]);

            var sumCost = 0;
            for (int i = 0; i < HW[0]; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                foreach (int r in read) if (r != -1) sumCost += changeCosts[r, 1];
            }
            Console.WriteLine(sumCost);
        }
    }
}
