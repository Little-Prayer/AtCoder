using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var NX = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NX[0]; var X = NX[1];
            var canJumping = new bool[N + 1, X + 1];
            canJumping[0, 0] = true;
            for (int i = 1; i <= N; i++)
            {
                var ab = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j + ab[0] <= X; j++)
                {
                    if (canJumping[i - 1, j])
                    {
                        canJumping[i, j + ab[0]] = true;
                        if (j + ab[1] <= X) canJumping[i, j + ab[1]] = true;
                    }
                }
            }
            Console.WriteLine(canJumping[N, X] ? "Yes" : "No");
        }
    }
}
