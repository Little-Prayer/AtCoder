using System;

namespace ARC069_D___Menagerie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static string solver()
        {
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var talk = new int[N];
            for (int i = 0; i < N; i++) talk[i] = S[i] == 'o' ? 1 : -1;
            if (check(talk, 1, 1) != "") return check(talk, 1, 1);
            if (check(talk, 1, -1) != "") return check(talk, 1, -1);
            if (check(talk, -1, 1) != "") return check(talk, -1, 1);
            if (check(talk, -1, -1) != "") return check(talk, -1, -1);
            return "-1";
        }
        static string check(int[] talk, int first, int second)
        {
            var N = talk.Length;
            var arrangement = new int[N];
            var result = new System.Text.StringBuilder();
            arrangement[0] = first;
            arrangement[1] = second;
            for (int i = 1; i < talk.Length - 1; i++) arrangement[i + 1] = arrangement[i - 1] * arrangement[i] * talk[i];
            if (arrangement[N - 1] * arrangement[N - 2] * talk[N - 1] != arrangement[0]) return "";
            if (arrangement[0] * arrangement[1] * talk[0] != arrangement[N - 1]) return "";
            for (int i = 0; i < N; i++) result.Append(arrangement[i] == 1 ? "S" : "W");
            return result.ToString();
        }
    }
}
