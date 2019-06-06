using System;

namespace ABC061_C___Big_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            var N = read[0];
            var K = read[1];

            var numbers = new long[100100];

            for(int i = 0 ; i < N ; i++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
                numbers[read[0]] += read[1];
            }

            int result = 0;

            while(K > numbers[result])
            {
                K -= numbers[result];
                result += 1;
            }

            Console.WriteLine(result);
        }
    }
}
