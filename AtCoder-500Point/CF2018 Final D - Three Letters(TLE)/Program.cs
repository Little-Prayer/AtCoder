using System;

namespace CF2018_Final_D___Three_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var words = new string[N];
            for (int i = 0; i < N; i++) words[i] = Console.ReadLine();

            var abbreviation = new int[52, 52, 52];
            foreach (string s in words)
            {
                var used = new bool[52, 52, 52];
                if (s.Length > 52)
                {
                    var index = new int[52, 2];
                    for (int j = 0; j < 52; j++) for (int k = 0; k < 2; k++) index[j, k] = int.MaxValue;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (index[c2i(s[i]), 0] > i) index[c2i(s[i]), 0] = i;
                        index[c2i(s[i]), 1] = i;
                    }

                    for (int center = 1; center < s.Length - 1; center++)
                    {
                        for (int left = 0; left < 52; left++)
                        {
                            for (int right = 0; right < 52; right++)
                            {
                                if (index[left, 0] < center && index[right, 1] > center && !used[left, c2i(s[center]), right])
                                {
                                    used[left, c2i(s[center]), right] = true;
                                    abbreviation[left, c2i(s[center]), right]++;
                                }
                            }
                        }
                    }

                }
                else
                {
                    for (int left = 0; left < s.Length - 2; left++)
                    {
                        for (int center = left + 1; center < s.Length - 1; center++)
                        {
                            for (int right = center + 1; right < s.Length; right++)
                            {
                                if (!used[c2i(s[left]), c2i(s[center]), c2i(s[right])])
                                {
                                    abbreviation[c2i(s[left]), c2i(s[center]), c2i(s[right])]++;
                                    used[c2i(s[left]), c2i(s[center]), c2i(s[right])] = true;
                                }
                            }
                        }
                    }
                }
            }
            var maxCount = 0;
            var maxL = 0; var maxC = 0; var maxR = 0;
            for (int l = 0; l < 52; l++)
            {
                for (int c = 0; c < 52; c++)
                {
                    for (int r = 0; r < 52; r++)
                    {
                        if (maxCount < abbreviation[l, c, r])
                        {
                            maxCount = abbreviation[l, c, r];
                            maxL = l; maxC = c; maxR = r;
                        }
                    }
                }
            }
            Console.Write(i2c(maxL));
            Console.Write(i2c(maxC));
            Console.Write(i2c(maxR));
        }
        static int c2i(char c)
        {
            if (c >= 'A' && c <= 'Z') return c - 'A';
            else return c - 'a' + 26;
        }
        static char i2c(int i)
        {
            if (i >= 0 && i <= 25) return (char)(i + 'A');
            else return (char)(i - 26 + 'a');
        }
    }
}
