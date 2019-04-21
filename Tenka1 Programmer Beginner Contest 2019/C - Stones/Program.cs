using System;

namespace C___Stones
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();

            var stoneGroup = new int[100000];
            var stoneCount = 1;
            var groupCount = 0;

            for (int i = 1 ; i < N ; i++)
            {
                if(S[i]==S[i-1])
                {
                    stoneCount++;
                }else{
                    stoneGroup[groupCount] = stoneCount;
                    stoneCount = 1;
                }
            }

            int j;
            int result = 0;
            if(S[0] == '#')
            {
                j = 0;
            }else{
                j = 1;
            }

            for(;j<groupCount;j+=2)
            {
                if(stoneGroup[j]<=stoneGroup[j+1])
                {
                    result += stoneGroup[j];
                }else{
                    result += stoneGroup[j+1];
                }
            }

            Console.WriteLine(result);
        }
    }
}
