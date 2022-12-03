using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var HM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HM[0]; var M = HM[1];
            while (true)
            {
                if (isMisjudge(H, M)) break;
                if (M == 59)
                {
                    M = 0;
                    H = (H + 1) % 24;
                }
                else
                {
                    M++;
                }
            }
            Console.WriteLine($"{H} {M}");
        }
        static bool isMisjudge(int H, int M)
        {
            var A = H / 10;
            var B = H % 10;
            var C = M / 10;

            if (B >= 6) return false;
            if (A == 2)
            {
                if (C >= 4) return false;
            }
            return true;
        }
    }
}
