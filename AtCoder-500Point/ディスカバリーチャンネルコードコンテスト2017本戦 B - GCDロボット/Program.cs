using System;

namespace ディスカバリーチャンネルコードコンテスト2017本戦_B___GCDロボット
{
    class Program
    {
        static void Main(string[] args)
        {
            var NZ = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = (int)NZ[0]; var Z = NZ[1];
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            long result = 1;
            for (int i = 0; i < N; i++)
            {
                result = LCM(result, GCD(Z, a[i]));
            }
            Console.WriteLine(result);

        }

        static long GCD(long A, long B)
        {
            if (B > A) return GCD(B, A);
            if (A % B == 0)
            {
                return B;
            }
            else
            {
                return GCD(B, A % B);
            }
        }

        static long LCM(long A, long B)
        {
            return A / GCD(A, B) * B;
        }
    }
}
