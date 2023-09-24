var N = int.Parse(Console.ReadLine()!);

var changes = new long[100000 + 1];
for (int i = 1; i <= 100000; i++) changes[i] = long.MaxValue;

var xyz = new long[N + 1, 3];
for (int i = 1; i <= N; i++)
{
    var read = Array.ConvertAll(Console.ReadLine()!.Split(' '), long.Parse);
    xyz[i, 0] = read[0];
    xyz[i, 1] = read[1];
    xyz[i, 2] = read[2];
}

long totalSeats = 0;
for (int i = 1; i <= N; i++) totalSeats += xyz[i, 2];

for (int i = 1; i <= N; i++)
{
    var x = xyz[i, 0]; var y = xyz[i, 1]; var z = xyz[i, 2];

    for (long j = totalSeats - z; j >= 0; j--)
    {
        if (changes[j] != long.MaxValue)
        {
            changes[j + z] = Math.Min(changes[j + z], changes[j] + Math.Max(0, (y - x) / 2 + 1));
        }
    }
}

var result = long.MaxValue;
for (long i = totalSeats / 2 + 1; i <= totalSeats; i++)
{
    if (result > changes[i]) result = changes[i];
}
Console.WriteLine(result);