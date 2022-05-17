using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var an = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var a = an[0]; var N = an[1];
            var queue = new Queue<int>();
            var max = 1000000;
            var check = new int[max + 1];
            for (int i = 0; i < max + 1; i++) check[i] = -1;
            check[1] = 0;

            queue.Enqueue(1);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current * a < max && check[current * a] < 0)
                {
                    queue.Enqueue(current * a);
                    check[current * a] = check[current] + 1;
                }
                var strcur = current.ToString();
                if (strcur.Length > 1 && (strcur[strcur.Length - 1] != '0'))
                {
                    var rotate = int.Parse(strcur[strcur.Length - 1].ToString() + strcur.Substring(0, strcur.Length - 1));
                    if (check[rotate] < 0)
                    {
                        queue.Enqueue(rotate);
                        check[rotate] = check[current] + 1;
                    }
                }
            }
            Console.WriteLine(check[N]);

        }
    }
}
