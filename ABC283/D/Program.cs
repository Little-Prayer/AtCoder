using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var S = Console.ReadLine();
            var box = new int[26];
            for (int i = 0; i < 26; i++) box[i] = -1;
            var depth = 0;

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                {
                    depth += 1;
                }
                else if (S[i] == ')')
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (box[j] == depth) box[j] = -1;
                    }
                    depth -= 1;
                }
                else
                {
                    if (box[S[i] - 'a'] >= 0)
                    {
                        return false;
                    }
                    else
                    {
                        box[S[i] - 'a'] = depth;
                    }
                }
            }

            return true;
        }
    }
}
