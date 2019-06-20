using System;
using System.Linq;

namespace ABC085_D___Katana_Thrower
{
    class Program
    {
        static void Main(string[] args)
        {
            var NH = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NH[0];
            var H = NH[1];
            var attack = new int[N];
            var throwing = new int[N];

            for (int i = 0; i < N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                attack[i] = ab[0];
                throwing[i] = ab[1];
            }

            var attackMax = attack.Max();
            throwing = throwing.Where(s => s > attackMax).OrderByDescending(s => s).ToArray();

            var attackCount = 0;
            while (attackCount < throwing.Length && H > 0)
            {
                H -= throwing[attackCount];
                attackCount += 1;
            }
            if (H > 0)
            {
                attackCount += H / attackMax;
                if ((H % attackMax) > 0) attackCount += 1;
            }
            Console.WriteLine(attackCount);
        }
    }
}
