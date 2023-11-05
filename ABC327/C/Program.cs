var map = new int[9, 9];
for (int row = 0; row < 9; row++)
{
    var read = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);
    for (int col = 0; col < 9; col++)
    {
        map[row, col] = read[col];
    }
}

var result = true;
for (int row = 0; row < 9; row++)
{
    if (!result) break;
    var checker = new bool[10];
    for (int col = 0; col < 9; col++)
    {
        if (checker[map[row, col]])
        {
            result = false;
            break;
        }
        else
        {
            checker[map[row, col]] = true;
        }
    }
}

for (int col = 0; col < 9; col++)
{
    if (!result) break;
    var checker = new bool[10];
    for (int row = 0; row < 9; row++)
    {
        if (checker[map[row, col]])
        {
            result = false;
            break;
        }
        else
        {
            checker[map[row, col]] = true;
        }
    }
}

for (int boxRow = 0; boxRow < 9; boxRow += 3)
{
    for (int boxCol = 0; boxCol < 9; boxCol += 3)
    {
        if (!result) break;
        var checker = new bool[10];

        for (int row = boxRow; row < boxRow + 3; row++)
        {
            for(int col = boxCol;col<boxCol+3;col++)
            {
                if (checker[map[row, col]])
                {
                    result = false;
                    break;
                }
                else
                {
                    checker[map[row, col]] = true;
                }
            }
        }
    }
}

Console.WriteLine(result ? "Yes" : "No");


