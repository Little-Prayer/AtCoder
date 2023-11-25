var N = int.Parse(Console.ReadLine()!);
var map = new bool[N, N];

for (int row = 0; row < N; row++)
{
    var read = Console.ReadLine()!;
    for (int col = 0; col < N; col++) map[row, col] = read[col] == 'o';
}

var rowCount = new long[N];
for (int row = 0; row < N; row++)
{
    var count = 0;
    for (int col = 0; col < N; col++)
    {
        if (map[row, col]) count++;
    }
    rowCount[row] = count;
}

var colCount = new long[N];
for (int col = 0; col < N; col++)
{
    var count = 0;
    for (int row = 0; row < N; row++)
    {
        if (map[row, col]) count++;
    }
    colCount[col] = count;
}

long result = 0;
for (int row = 0; row < N; row++)
{
    for (int col = 0; col < N; col++)
    {
        if (map[row, col])
        {
            result += (rowCount[row] - 1) * (colCount[col] - 1);
        }
    }
}
Console.WriteLine(result);