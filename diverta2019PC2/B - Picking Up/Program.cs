using System;
using System.Linq;

namespace B___Picking_Up
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var xy  = new long[N,2];

            for(int i = 0 ; i < N ; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
                xy[i,0] = read[0];
                xy[i,1] = read[1];
            }
            var differenceX = new long[N,N];
            var differenceY = new long[N,N];

            for(int i = 0 ; i < N ; i++)
            {
                for(int j = 0 ; j < N ; j++)
                {
                    if(i==j)continue;
                    differenceX[i,j] = xy[i,0] - xy[j,0];
                    differenceY[i,j] = xy[i,1] - xy[j,1];
                }
            }

            var isChecked = new bool[N,N];
            for(int i = 0 ; i<N;i++)for(int j = 0 ; j<N ; j++) isChecked[i,j] = false;
            var maxCount = 0;
            for(int i = 0 ; i < N ; i++)
            {
                for(int j = 0 ; j < N ; j++)
                {
                    if(i ==j)continue;
                    if(isChecked[i,j]) continue;
                    var checkCount = 1;
                    isChecked[i,j] = true;
                    for(int m = 0 ; m < N ; m++)
                    {
                        for(int n = 0 ; n<N ; n++)
                        {
                            if(m == i && n == j)continue;
                            if(differenceX[m,n]==differenceX[i,j] && differenceY[i,j]==differenceY[m,n])
                            {
                                isChecked[m,n] = true;
                                checkCount += 1;
                            }
                        }
                    }
                    maxCount = Math.Max(maxCount,checkCount);
                }
            }

            Console.WriteLine(N-maxCount);

        }
    }
}
