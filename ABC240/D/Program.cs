using System;
using System.Collections.Generic;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var count = 0;
            var stack = new Stack<balls>();

            for (int i = 0; i < N; i++)
            {
                if (count == 0)
                {
                    stack.Push(new balls(A[i]));
                    count++;
                }
                else
                {
                    var current = stack.Pop();
                    if (current.number != A[i])
                    {
                        stack.Push(current);
                        stack.Push(new balls(A[i]));
                        count++;
                    }
                    else
                    {
                        if (current.number == current.count + 1)
                        {
                            count -= current.count;
                        }
                        else
                        {
                            current.count++;
                            stack.Push(current);
                            count++;
                        }
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
    class balls
    {
        public int number;
        public int count;
        public balls(int n)
        {
            number = n;
            count = 1;
        }
    }
}
