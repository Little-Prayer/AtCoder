using System;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new bool[9, 9];
            for (int i = 0; i < 9; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < 9; j++) map[i, j] = (line[j] == '#');
            }

            var result = 0;
            for (int startRow = 0; startRow < 9; startRow++)
            {
                for (int startCol = 0; startCol < 9; startCol++)
                {
                    if (!map[startRow, startCol]) continue;
                    for (int addRow = 0; startRow + addRow < 9; addRow++)
                    {
                        for (int addCol = 1; startCol + addCol < 9; addCol++)
                        {
                            if (addRow == 0 && addCol == 0) continue;
                            if (startCol - addRow < 0) break;
                            if (startRow + addRow + addCol >= 9) break;
                            if (!map[startRow + addRow, startCol + addCol]) continue;
                            if (!map[startRow + addCol, startCol - addRow]) continue;
                            if (!map[startRow + addRow + addCol, startCol + addCol - addRow]) continue;
                            result++;
                        }
                    }
                }
            }
            Console.WriteLine(result);
        }

    }
}
