using System;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var league = new string[N];
            for (int i = 0; i < N; i++) league[i] = Console.ReadLine();
            var result = true;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (league[i][j] == 'W' && league[j][i] != 'L')
                    {
                        result = false;
                        break;
                    }
                    if (league[i][j] == 'L' && league[j][i] != 'W')
                    {
                        result = false;
                        break;
                    }
                    if (league[i][j] == 'D' && league[j][i] != 'D')
                    {
                        result = false;
                        break;
                    }
                }
                if (!result) break;
            }
            Console.WriteLine(result ? "correct" : "incorrect");
        }
    }
}
