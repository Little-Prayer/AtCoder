using System;

namespace AGC019_B___Reverse_and_Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = Console.ReadLine();
            var alphabets = new long[26];
            for (int i = 0; i < A.Length; i++) alphabets[A[i] - 'a']++;
            long result = (long)A.Length * (long)(A.Length - 1) / 2 + 1;
            for (int i = 0; i < 26; i++) result -= alphabets[i] * (alphabets[i] - 1) / 2;

            Console.WriteLine(result);
        }
    }
}
