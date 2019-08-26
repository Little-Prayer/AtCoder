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
                if (FS == ABQ[0]) FS = FS - 1;

                var FT = lowerBound(temples, q);
                var BT = FT != 0 ? FT - 1 : 0;
                if (FT == ABQ[1]) FT = FT - 1;

                long result = long.MaxValue;
                Func<long, long, long> f = (a, b) => Math.Min(result, Math.Abs(q - a) + Math.Abs(a - b));
                result = f(shrines[FS], temples[FT]);
                result = f(shrines[FS], temples[BT]);
                result = f(shrines[BS], temples[FT]);
                result = f(shrines[BS], temples[BT]);
                result = f(temples[FT], shrines[FS]);
                result = f(temples[FT], shrines[BS]);
                result = f(temples[BT], shrines[FS]);
                result = f(temples[BT], shrines[BS]);
                Console.WriteLine(result);
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
    }
}
