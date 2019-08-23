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
                var FS = lowerBound(shrines, q);
                var BS = FS != 0 ? FS - 1 : 0;

                var FT = lowerBound(temples, q);
                var BT = FT != 0 ? FT - 1 : 0;
            }
        }
        static int lowerBound(long[] array, long start)
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
        static long searchingNearest(long[] array, long start)
        {
            var index = lowerBound(array, start);
            if (index == 0) return array[0];
            if (index == array.Length) return array[array.Length - 1];
            return array[index] - start < start - array[index - 1] ? array[index] : array[index - 1];
        }

    }
}
