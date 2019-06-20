using System;

namespace ABC086_C___Traveling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(canTraveling() ? "Yes" : "No");
        }
        static bool canTraveling()
        {
            var N = int.Parse(Console.ReadLine());
            var plan = new int[N + 1, 3];

            for (int i = 1; i < N + 1; i++)
            {
                var txy = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                plan[i, 0] = txy[0];
                plan[i, 1] = txy[1];
                plan[i, 2] = txy[2];
            }

            for (int i = 1; i < N + 1; i++)
            {
                var differenceT = plan[i, 0] - plan[i - 1, 0];
                var differenceX = Math.Abs(plan[i, 1] - plan[i - 1, 1]);
                var differenceY = Math.Abs(plan[i, 2] - plan[i - 1, 2]);

                if (differenceX + differenceY > differenceT) return false;
                if (((differenceX + differenceY) % 2) != (differenceT % 2)) return false;
            }

            return true;
        }
    }
}
