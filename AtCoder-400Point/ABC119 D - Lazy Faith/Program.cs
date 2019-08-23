using System;

namespace ABC119_D___Lazy_Faith
{
    class Program
    {
        static void Main(string[] args)
        {
            var ABQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var shrines = new long[ABQ[0]];
            for (int i = 0; i < ABQ[0]; i++) shrines[i] = long.Parse(Console.ReadLine());

            var temples = new long[ABQ[1]];
            for (int i = 0; i < ABQ[1]; i++) temples[i] = long.Parse(Console.ReadLine());

            var questions = new long[ABQ[2]];
            for (int i = 0; i < ABQ[2]; i++) questions[i] = long.Parse(Console.ReadLine());

            foreach (long q in questions)
            {
                var forwardShrine = lowerBound(shrines, q);
                var backwardShrine = forwardShrine != 0 ? forwardShrine - 1 : 0;

                var forwardTemple = lowerBound(temples, q);
                var backwardTemple = forwardTemple != 0 ? forwardTemple - 1 : 0;
            }
        }
        static long lowerBound(long[] array, long start)
        {
            int left = -1;
            int right = array.Length;

            while (right - left > 1)
            {
                int mid = (left) + (right - left) / 2;
                if (array[mid] >= start) right = mid; else left = mid;
            }
            return right;
        }
    }
}
