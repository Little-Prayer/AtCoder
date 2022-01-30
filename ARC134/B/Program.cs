using System;
using System.Collections.Generic;
using System.Linq;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine().ToCharArray();

            var alphabets = new List<int>[26];
            for (int i = 0; i < 26; i++) alphabets[i] = new List<int>();
            for (int i = 0; i < N; i++) alphabets[S[i] - 'a'].Add(i);

            var start = 0; var end = N - 1;
            var current = 0;
            while (start < end)
            {
                var currentalphabet = alphabets[current].Where(x => x > start).Where(x => x <= end);
                while (currentalphabet.Count() == 0)
                {
                    current++;
                    if (current >= 26) break;
                    currentalphabet = alphabets[current].Where(x => x > start).Where(x => x <= end);
                }
                if (current >= 26) break;
                if (current >= S[start] - 'a')
                {
                    start++;
                    continue;
                }
                var opponent = currentalphabet.Max();

                S[opponent] = S[start];
                S[start] = (char)(current + 'a');
                start++;
                end = opponent - 1;

            }
            Console.WriteLine(new string(S));
        }
    }
}

