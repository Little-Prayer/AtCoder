using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var X = Console.ReadLine();

            var fn = new int[N + 1];
            fn[1] = 1;
            for (int i = 2; i <= N; i++)
            {
                var temp = i % popcount(i);
                fn[i] = fn[temp] + 1;
            }

            var count1 = X.Length - X.Replace("1", "").Length;
            var modPlus = 0;
            var modMinus = 0;
            var modp = 1;
            var modm = 1;
            for (int i = N - 1; i >= 0; i--)
            {
                if (X[i] == '1')
                {
                    modPlus += modp;
                    modPlus %= count1 + 1;
                    if (count1 > 1)
                    {
                        modMinus += modm;
                        modMinus %= count1 - 1;
                    }
                }
                modp = (modp * 2) % (count1 + 1);
                if (count1 > 1)
                    modm = (modm * 2) % (count1 - 1);
            }
            var Xi = new int[N];
            modp = 1;
            modm = 1;
            for (int i = N - 1; i >= 0; i--)
            {
                if (X[i] == '1')
                {
                    if (count1 > 1)
                    {
                        if (modMinus - modm < 0) modMinus += count1 - 1;
                        Xi[i] = fn[(modMinus - modm) % (count1 - 1)] + 1;
                    }
                    else
                    {
                        Xi[i] = 0;
                    }
                }
                else
                {

                    if (modPlus - modp < 0) modPlus += count1 + 1;
                    Xi[i] = fn[(modPlus + modp) % (count1 + 1)] + 1;
                }
                modp = (modp * 2) % (count1 + 1);
                if (count1 > 1)
                    modm = (modm * 2) % (count1 - 1);
            }
            Console.WriteLine(string.Join("\n", Xi));
        }


        static int popcount(int X)
        {
            var result = 0;
            while (X > 0)
            {
                if ((X % 2) == 1) result++;
                X /= 2;
            }
            return result;
        }
    }
}
