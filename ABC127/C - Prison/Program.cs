using System;

namespace C___Prison
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            int N = read[0];
            int M = read[1];

            int Lmax = 1;
            int Rmin = N;

            for(int i = 0 ; i < M ; i++)
            {
                var LR = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
                if(Lmax < LR[0]) Lmax = LR[0];
                if(Rmin > LR[1]) Rmin = LR[1];
            }
            var result = Lmax <= Rmin ? Rmin-Lmax + 1 : 0 ;
            Console.WriteLine(result);
        }
    }
}
