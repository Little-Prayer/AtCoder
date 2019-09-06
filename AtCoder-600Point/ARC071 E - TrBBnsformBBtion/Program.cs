using System;

namespace ARC071_E___TrBBnsformBBtion
{
    class Program
    {
        static void Main(string[] args)
        {
            var S = Console.ReadLine();
            var T = Console.ReadLine();

            var accumAS = new int[S.Length + 1];
            for (int i = 1; i < S.Length + 1; i++) accumAS[i] = accumAS[i - 1] + (S[i - 1] == 'B' ? 2 : 1);

            var accumBS = new int[S.Length + 1];
            for (int i = 1; i < S.Length + 1; i++) accumBS[i] = accumBS[i - 1] + (S[i - 1] == 'A' ? 2 : 1);

            var accumAT = new int[T.Length + 1];
            for (int i = 1; i < T.Length + 1; i++) accumAT[i] = accumAT[i - 1] + (T[i - 1] == 'B' ? 2 : 1);

            var accumBT = new int[T.Length + 1];
            for (int i = 1; i < T.Length + 1; i++) accumBT[i] = accumBT[i - 1] + (T[i - 1] == 'A' ? 2 : 1);



            var q = int.Parse(Console.ReadLine());
            for (int i = 0; i < q; i++)
            {
                var abcd = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                var a = abcd[0]; var b = abcd[1]; var c = abcd[2]; var d = abcd[3];

                var partAS = accumAS[b] - accumAS[a - 1];
                var partAT = accumAT[d] - accumAT[c - 1];
                var partBS = accumBS[b] - accumBS[a - 1];
                var partBT = accumBT[d] - accumBT[c - 1];
                var canConversion = (Math.Abs(partAT - partAS) % 3 == 0) || (Math.Abs(partBT - partBS) % 3 == 0);
                Console.WriteLine(canConversion ? "YES" : "NO");
            }
        }
    }
}
