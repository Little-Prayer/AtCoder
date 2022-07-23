using System;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var NC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NC[0]; var X = NC[1];
            var operation = new int[N + 1, 32, 2];
            for (int i = 0; i < 32; i++) for (int j = 0; j <= 1; j++) operation[0, i, j] = j;

            for (var op = 1; op <= N; op++)
            {
                var TA = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (var bit = 0; bit < 32; bit++)
                {
                    var current = (TA[1] & (1 << bit)) > 0 ? 1 : 0;
                    for (int input = 0; input <= 1; input++)
                    {
                        if (TA[0] == 1) operation[op, bit, input] = (operation[op - 1, bit, input] & current) > 0 ? 1 : 0;
                        if (TA[0] == 2) operation[op, bit, input] = (operation[op - 1, bit, input] | current) > 0 ? 1 : 0;
                        if (TA[0] == 3) operation[op, bit, input] = (operation[op - 1, bit, input] ^ current) > 0 ? 1 : 0;
                    }
                }
            }

            for (var op = 1; op <= N; op++)
            {
                var output = 0;
                for (int bit = 0; bit < 32; bit++)
                {
                    var current = (X & (1 << bit)) > 0 ? 1 : 0;
                    output += operation[op, bit, current] << bit;
                }
                Console.WriteLine(output);
                X = output;
            }
        }
    }
}

