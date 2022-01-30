using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");

            bool solver()
            {
                var S = Console.ReadLine();
                bool isPalindrome(string text)
                {
                    for (int i = 0; i < text.Length - 1 - i; i++)
                        if (text[i] != text[text.Length - i - 1]) return false;
                    return true;
                }
                if (isPalindrome(S)) return true;
                var front = 0;
                while (S[front] == 'a') front++;
                var rear = 0;
                while (S[S.Length - rear - 1] == 'a') rear++;
                if (front > rear) return false;
                if (isPalindrome(S.Substring(front, S.Length - front - rear))) return true;
                return false;
            }
        }
    }
}
