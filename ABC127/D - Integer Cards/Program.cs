using System;
using System.Linq;

namespace D___Integer_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            var N = read[0];
            var M = read[1];

            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            Array.Sort(Ai);

            var BiCi = new BC[M];
            for(int i = 0 ; i < M ; i++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
                BiCi[i] = new BC();
                BiCi[i].B = read[0];
                BiCi[i].C = read[1];
            }
            BiCi = BiCi.OrderByDescending(BC => BC.C).ToArray();

            long count = 0;
            for(int i = 0 ; i < M ; i++)
            {
                for(int j = 0 ;j < BiCi[i].B ; j++)
                {
                    if(Ai[count] < BiCi[i].C)
                    {
                        Ai[count] = BiCi[i].C;
                        count++;
                    }else{
                        break;
                    }
                }
            }
            Console.WriteLine(Ai.Sum());
            Console.ReadKey();
        }
    }
    public struct BC
    {
        public long B{get;set;}
        public long C{get;set;}
    }
}
