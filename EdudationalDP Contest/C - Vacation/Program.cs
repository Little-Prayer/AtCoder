using System;
using System.Linq;

namespace C___Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var vacation = new int[N+1,3];

            for(int i = 1 ; i < N+1 ; i++)
            {
                var Read = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                vacation[i,0] = Read[0];
                vacation[i,1] = Read[1];
                vacation[i,2] = Read[2];
            }

            var happiness = new long[N+1,3];
            for(int i = 1 ; i < N+1 ; i++)
            {
                happiness[i,0] = Math.Max(happiness[i-1,1],happiness[i-1,2]) + vacation[i,0];
                happiness[i,1] = Math.Max(happiness[i-1,0],happiness[i-1,2]) + vacation[i,1];
                happiness[i,2] = Math.Max(happiness[i-1,0],happiness[i-1,1]) + vacation[i,2];
            }

            Console.WriteLine(Math.Max(happiness[N,2],Math.Max(happiness[N,0],happiness[N,1])));

        }
    }
}
