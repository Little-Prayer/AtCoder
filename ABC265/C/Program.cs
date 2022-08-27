using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }

        static string solver()
        {
            var HW = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var H = HW[0]; var W = HW[1];

            var map = new string[H];
            var isPassing = new bool[H, W];
            for (int i = 0; i < H; i++)
            {
                var read = Console.ReadLine();
                map[i] = read;
            }

            var ch = 0;
            var cw = 0;

            while (true)
            {
                if (isPassing[ch, cw]) return "-1";
                var isMove = true;
                isPassing[ch, cw] = true;

                if (map[ch][cw] == 'U')
                {
                    if (ch == 0) isMove = false;
                    else ch--;
                }
                if (map[ch][cw] == 'D')
                {
                    if (ch == H - 1) isMove = false;
                    else ch++;
                }
                if (map[ch][cw] == 'L')
                {
                    if (cw == 0) isMove = false;
                    else cw--;
                }
                if (map[ch][cw] == 'R')
                {
                    if (cw == W - 1) isMove = false;
                    else cw++;
                }

                if (!isMove) return ($"{ch + 1} {cw + 1}");
            }
        }
    }
}
