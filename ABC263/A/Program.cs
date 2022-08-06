using System;
using System.Collections.Generic;
using System.Linq;

namespace A
{
    class Program
    {
        static void Main(string[] args)
        {
            var cards = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var dic = new Dictionary<int, int>();
            foreach (int card in cards)
            {
                if (dic.ContainsKey(card))
                {
                    dic[card]++;
                }
                else
                {
                    dic.Add(card, 1);
                }
            }

            if (dic.Values.Max() == 3)
            {
                if (dic.Values.Min() == 2)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
