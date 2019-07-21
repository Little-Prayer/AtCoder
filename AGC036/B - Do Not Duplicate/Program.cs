using System;
using System.Collections.Generic;
using System.Linq;

namespace B___Do_Not_Duplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var numberIndex = new List<int>[Ai.Max() + 1];
            for (int i = 0; i < numberIndex.Count(); i++) numberIndex[i] = new List<int>();
            for (int i = 0; i < Ai.Length; i++) numberIndex[Ai[i]].Add(i);

            var periodCount = 1;
            var periodLastIndex = new List<int>();
            var currentIndex = -1;
            while (currentIndex != NK[0] - 1)
            {
                currentIndex += 1;
                var prevIndex = currentIndex;
                var currentNumber = Ai[currentIndex];
                currentIndex = numberIndex[currentNumber][binary_search(numberIndex[currentNumber], currentIndex)];
                if (currentIndex == prevIndex)
                {
                    currentIndex = numberIndex[currentNumber][0];
                    periodLastIndex.Add(prevIndex);
                    periodCount += 1;
                }
            }
            Console.WriteLine(periodCount);
        }
        static int binary_search(List<int> list, int key)
        {
            int left = -1;
            int right = list.Count;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] > key)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }
            return right;
        }
    }
}
