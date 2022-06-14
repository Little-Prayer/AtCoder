using System;

namespace _044___Shift_and_Swapping_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NQ = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NQ[0]; var Q = NQ[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var swap = new int[N];
            for (int i = 0; i < N; i++) swap[i] = i;
            var shift = 0;

            for (int i = 0; i < Q; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                switch (read[0])
                {
                    case 1:
                        read[1] -= shift + 1;
                        if (read[1] < 0) read[1] += N;
                        read[2] -= shift + 1;
                        if (read[2] < 0) read[2] += N;
                        var temp = swap[read[1]];
                        swap[read[1]] = swap[read[2]];
                        swap[read[2]] = temp;
                        break;
                    case 2:
                        shift++;
                        shift %= N;
                        break;
                    case 3:
                        read[1] -= shift + 1;
                        if (read[1] < 0) read[1] += N;
                        Console.WriteLine(A[swap[read[1]]]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
