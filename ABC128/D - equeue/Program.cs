using System;
using System.Collections.Generic;
using System.Linq;

namespace D___equeue
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var K = read[1];
            var V = new List<int>();
            V.AddRange(Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse));

            var atHand = new List<int>();
            long maxValue = 0;

            for(int toFirst = 0 ; toFirst <= Math.Max(K,N) ; toFirst++)
            {
                for(int toLast = 0 ; toLast <= K-toFirst ; toLast++)
                {
                    for(int getFirst = 0 ; getFirst < toFirst ; getFirst++)atHand.Add(V[getFirst]);
                    for(int getLast = 0 ; getLast < toLast ; getLast++)atHand.Add(V[V.Count-1-getLast]);
                    atHand = atHand.OrderBy(s => s).ToList();
                    var trash = Math.Min(K - toFirst - toLast,atHand.Count);
                    for(int i = 0 ; i < trash ; i++)atHand[i] = 0;
                    var totalValue = atHand.Sum();
                    if(maxValue<totalValue) maxValue=totalValue;
                }
            }
            Console.WriteLine(maxValue);
        }
    }
}
