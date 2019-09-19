using System;
using System.Linq;
using System.Collections.Generic;

namespace M_SOLUTIONSプロコンオープン_D___Maximum_Sum_of_Minimum
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var connections = new List<int>[N + 1];
            for (int i = 0; i < N + 1; i++) connections[i] = new List<int>();
            for (int i = 0; i < N - 1; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connections[ab[0]].Add(ab[1]);
                connections[ab[1]].Add(ab[0]);
            }

            var C = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).OrderByDescending(n => n).ToArray();
            var sum = C.Sum() - C[0];
            var Cqueue = new Queue<int>(C);
            var numbers = new int[N];
            var queue = new Queue<int>();
            queue.Enqueue(1);
            var Cmax = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                numbers[current - 1] = Cqueue.Dequeue();
                foreach (int i in connections[current]) if (numbers[i - 1] == 0) queue.Enqueue(i);
            }
            Console.WriteLine(sum);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
