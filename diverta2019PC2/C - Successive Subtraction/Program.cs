using System;

namespace C___Successive_Subtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            Array.Sort(Ai);

            var max = Ai[Ai.Length-1];
            var min = Ai[0];

            var result = new int[N-1,2];
            for(int i = 1 ; i < Ai.Length-1;i++)
            {
                if(Ai[i] < 0)
                {
                    result[i-1,0] = max;
                    result[i-1,1] = Ai[i];
                    max -= Ai[i];
                }
                else
                {
                    result[i-1,0] = min;
                    result[i-1,1] = Ai[i];
                    min -= Ai[i];
                }
            }
            result[N-2,0] = max;
            result[N-2,1] = min;
            Console.WriteLine(max-min);
            for(int i = 0 ;i < N-1 ; i++) Console.WriteLine("{0} {1}",result[i,0],result[i,1]);
        }
    }
}
