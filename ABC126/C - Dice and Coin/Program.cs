using System;

namespace C___Dice_and_Coin
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var K = read[1];

            double result = 0;
            for(int i = 1 ;  i < N+1 ; i++)
            {
                var count = 0;
                while(K > i * Math.Pow(2,count)) count++;
                result += 1 / (N * Math.Pow(2,count));
            }
            Console.WriteLine(result);
        }
    }
}
