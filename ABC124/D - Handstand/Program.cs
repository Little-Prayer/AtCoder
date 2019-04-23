using System;

namespace D___Handstand
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Console.ReadLine().Split(' ');
            var N = int.Parse(read[0]);
            var K = int.Parse(read[1]);

            var S = Console.ReadLine();

            var groups0 = new int[100010];
            var groups1 = new int[100010];

            var group0Count = 0;
            var group1COunt = 1;

            int i = 0;

            while(i < S.Length)
            {
                while(S[i] == '0')
                {

                }

                while(S[i] == '1')
                {
                    
                }
            }

        }
    }
}
