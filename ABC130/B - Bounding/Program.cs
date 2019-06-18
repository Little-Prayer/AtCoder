using System;

namespace B___Bounding
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var X = read[1];

            var Li = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);

            var acum = new int[N+1];
            acum[0] = 0;
            for(int i = 1 ; i < N+1 ; i++ ) acum[i] = acum[i-1] + Li[i-1];
            var result = 0;
            for(int i = 1 ; i < N+1 ; i++)
            {
                if(acum[i] > X)
                {
                    result = i;
                    break;
                }
            }
            if(acum[N] <= X) result = N+1;
            Console.WriteLine(result);
        }
    }
}
