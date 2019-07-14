using System;

namespace A___XOR_Circle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver() ? "Yes" : "No");
        }
        static bool solver()
        {
            var N = int.Parse(Console.ReadLine());
            var Ai = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var isChecked = new bool[N];

            Array.Sort(Ai);

            for (int i = 1; i < N; i++)
            {
                if (Array.BinarySearch(Ai, Ai[0] ^ Ai[i]) > 0)
                {
                    for (int j = 0; j < N; j++) isChecked[i] = false;
                    isChecked[0] = true;
                    isChecked[i] = true;
                    var check1 = Ai[i];
                    var check2 = Ai[0] ^ Ai[i];

                    for (int k = 0; k < N - 2; k++)
                    {
                        var nextNumber = Array.BinarySearch(Ai, check2);
                        if (nextNumber > 0 && !isChecked[nextNumber])
                        {
                            isChecked[nextNumber] = true;
                            var temp = check1 ^ check2;
                            check1 = check2;
                            check2 = temp;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (check2 == Ai[0]) return true;
                }
            }
            return false;
        }
    }
}
