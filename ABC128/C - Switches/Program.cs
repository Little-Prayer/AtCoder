using System;

namespace C___Switches
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var M = read[1];
            var bulbs = new int[M];
            for(int i = 0 ; i < M ; i++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
                for(int j = 1 ; j < read.Length ; j++)
                {
                    bulbs[i] += 1<<read[j]-1;
                }
            }
            var Pi = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var allOnCount = 0;

            for(int switches = 0 ; switches < 1<<N ; switches++)
            {
                bool allOn = true;
                for(int i = 0 ; i < M ; i++)
                {
                    var checker = switches & bulbs[i];
                    var lightup = 0;
                    while(checker != 0)
                    {
                        lightup += checker % 2;
                        checker /= 2;
                    }
                    if(lightup % 2 != Pi[i])
                    {
                        allOn = false;
                        break;
                    } 
                }
                if(allOn) allOnCount++;
            }

            Console.WriteLine(allOnCount);
        }
    }
}
