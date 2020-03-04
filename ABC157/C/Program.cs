using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NM[0]; var M = NM[1];
            var sc = new int[M, 2];
            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                sc[i, 0] = read[0];
                sc[i, 1] = read[1];
            }
            var check1 = false;
            int min;
            int max;
            if (N == 1)
            {
                min = 0; max = 9;
            }
            else if (N == 2)
            {
                min = 10; max = 99;
            }
            else
            {
                min = 100; max = 999;
            }
            for (int i = min; i <= max; i++)
            {
                var check = true;
                var str = i.ToString();
                for (int j = 0; j < M; j++)
                {
                    if (str[sc[j, 0] - 1] != sc[j, 1].ToString()[0])
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    Console.WriteLine(i);
                    check1 = true;
                    break;
                }
            }
            if (!check1) Console.WriteLine(-1);
        }
    }
}
