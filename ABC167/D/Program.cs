using System;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static int solver()
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var N = NK[0]; var K = NK[1];
            var A = new int[N + 1];
            var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            for (int i = 0; i < N; i++) A[i + 1] = read[i];
            var first = new long[N + 1];
            for (int i = 0; i < N + 1; i++) first[i] = -1;

            long move = 0;
            var position = 1;
            while (first[position] < 0)
            {
                first[position] = move;
                move++;
                position = A[position];
                if (move == K) return position;
            }
            var span = move - first[position];
            var reminder = (K - first[position]) % span;

            long move2 = 0;
            while (move2 < reminder)
            {
                position = A[position];
                move2++;
            }
            return position;
        }
    }
}
