using System;

namespace B___Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var Wi = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);

            var cumlative = new int[N+1];
            cumlative[0] = 0;
            for(int i = 1 ; i < N+1 ; i++) cumlative[i] = cumlative[i-1] + Wi[i-1];

            var result = int.MaxValue;
            for(int i = 0 ; i < N+1 ; i++)
            {
                var difference = Math.Abs(cumlative[i]-(cumlative[N]-cumlative[i]));
                if(difference < result) result = difference;
            }
            Console.WriteLine(result);
        }
    }
}
