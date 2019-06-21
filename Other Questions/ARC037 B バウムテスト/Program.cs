using System;
using System.Collections.Generic;

namespace ARC037_B_バウムテスト
{
    class Program
    {
        static void Main(string[] args)
        {
            var NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var connection = new bool[NM[0] + 1, NM[0] + 1];
            var isSearch = new bool[NM[0] + 1];

            for (int i = 0; i < NM[1]; i++)
            {
                var edge = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                connection[edge[0], edge[1]] = true;
                connection[edge[1], edge[0]] = true;
            }

            var result = 0;
            while (true)
            {
                int startNode = 0;
                bool isEnd = true;
                for (int i = 1; i < NM[0] + 1; i++)
                {
                    if (!isSearch[i])
                    {
                        isEnd = false;
                        startNode = i;
                    }
                }
                if (isEnd) break;

                bool isTree = true;

                var searchStack = new Stack<int[]>();
                searchStack.Push(new int[] { startNode, 0 });

                while (searchStack.Count != 0)
                {
                    var searchNode = searchStack.Pop();
                    isSearch[searchNode[0]] = true;
                    for (int i = 1; i < NM[0]; i++)
                    {
                        if (i != searchNode[1] && connection[searchNode[0], i])
                        {
                            if (isSearch[i])
                            {
                                isTree = false;
                            }
                            else
                            {
                                searchStack.Push(new int[] { i, searchNode[0] });
                            }
                        }
                    }
                }
                if (isTree) result += 1;
            }
            Console.WriteLine(result);
        }
    }
}
