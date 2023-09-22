var N = int.Parse(Console.ReadLine()!);

int totalSeats = 0;
var changes = new long[N + 1, 10000 + 1];
for (int i = 0; i <= N; i++)
    for (int j = 0; j <= 10000; j++)
        changes[i, j] = long.MaxValue;
changes[0, 0] = 0;

for (int ward = 1; ward <= N; ward++)
{
    var xyz = Console.ReadLine()!.Split(' ').Select(long.Parse).ToArray();
    var x = xyz[0]; var y = xyz[1]; var z = (int)xyz[2];

    totalSeats += z;

    for (int seats = 0; seats + z <= 10000; seats++)
    {
        if (changes[ward - 1, seats] == long.MaxValue) continue;

        changes[ward, seats] = Math.Min(changes[ward, seats], changes[ward - 1, seats]);

        var change = Math.Max((y - x) / 2 + 1, 0);
        changes[ward, seats + z] = Math.Min(changes[ward, seats + z], changes[ward - 1, seats] + change);
    }
}

var result = long.MaxValue;
for (int i = totalSeats / 2 + 1; i <= totalSeats; i++)
{
    if (result > changes[N, i]) result = changes[N, i];
}
Console.WriteLine(result);