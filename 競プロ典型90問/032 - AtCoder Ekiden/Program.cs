using System;
using System.Collections.Generic;
using System.Linq;

namespace _032___AtCoder_Ekiden
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<T[]> exhaustivelyEnumration<T>(params T[] arr) where T : IComparable<T>
            {
                bool nextPermutation<S>(S[] arr, out S[] result) where S : IComparable<S>
                {
                    int i;
                    for (i = arr.Length - 2; i >= 0; i--)
                        if (arr[i].CompareTo(arr[i + 1]) < 0)
                            break;

                    if (i < 0)
                    {
                        result = arr;
                        return false;
                    }
                    int j;
                    for (j = arr.Length - 1; j >= 0; j--)
                        if (arr[i].CompareTo(arr[j]) < 0)
                            break;

                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    Array.Reverse(arr, i + 1, arr.Length - i - 1);

                    result = arr;
                    return true;
                }
                Array.Sort(arr);
                yield return arr;
                while (nextPermutation(arr, out T[] result))
                {
                    yield return result;
                }
                yield break;
            }

            var N = int.Parse(Console.ReadLine());
            var cost = new int[N + 1, N + 1];
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < N; j++) cost[i + 1, j + 1] = read[j];
            }

            var M = int.Parse(Console.ReadLine());
            var hate = new bool[N + 1, N + 1];
            for (int i = 0; i < M; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                hate[read[0], read[1]] = true;
                hate[read[1], read[0]] = true;
            }

            var result = int.MaxValue;
            foreach (int[] current in exhaustivelyEnumration(Enumerable.Range(1, N).ToArray()))
            {
                var canRunning = true;
                for (int i = 1; i < N; i++)
                    if (hate[current[i], current[i - 1]])
                        canRunning = false;
                if (!canRunning) continue;

                var subtotal = 0;
                for (int i = 1; i <= N; i++)
                    subtotal += cost[current[i - 1], i];

                if (subtotal < result) result = subtotal;
            }
            Console.WriteLine(result != int.MaxValue ? result : -1);
        }
    }
}
