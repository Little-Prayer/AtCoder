using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N =int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var baseball = new int[3];
            var point = 0;

            foreach(int h in A)
            {
                switch(h)
                {
                case 1:
                    point +=baseball[2];
                    baseball[2]=baseball[1];
                    baseball[1]=baseball[0];
                    baseball[0]=1;
                    break;
                case 2:
                    point +=baseball[2]+baseball[1];
                    baseball[2]=baseball[0];
                    baseball[1]=1;
                    baseball[0]=0;
                    break;
                case 3:
                    point += baseball[0]+baseball[1]+baseball[2];
                    baseball[2]=1;
                    baseball[1]=0;
                    baseball[0]=0;
                    break;
                case 4:
                    point += baseball[0]+baseball[1]+baseball[2]+1;
                    baseball[2]=0;
                    baseball[1]=0;
                    baseball[0]=0;
                    break;
                }
            }
                            Console.WriteLine(point);
        }
    }
}
