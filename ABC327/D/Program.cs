using System.Collections.Generic;

var NM = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);
var N = NM[0]; var M = NM[1];
var S = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);
var T = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);

var connection = new SortedSet<int>[N + 1];
for (int i = 0; i < N + 1; i++) { connection[i] = new SortedSet<int>(); }

for (int i = 0; i < M; i++)
{
    connection[S[i]].Add(T[i]);
    connection[T[i]].Add(S[i]);
}

bool?[] color = new bool?[N + 1];
for (int i = 0; i < N + 1; i++) color[i] = null;

var check = new bool[N + 1];
var result = true;

for (int i = 1; i < N + 1; i++)
{
    if (check[i]) { continue; }
    check[i] = true;
    color[i] = true;
    var queue = new Queue<int>();
    queue.Enqueue(i);

    while (queue.TryDequeue(out int current))
    {
        check[current] = true;
        foreach (int target in connection[current])
        {
            if(target==current)
            {
                result = false;
                break;
            }
            if (check[target]) { continue; }

            if (color[target] is null)
            {
                color[target] = !color[current];
                queue.Enqueue(target);
            }
            else if (color[target] == color[current])
            {
                result = false;
                break;
            }
        }
        if (!result) break;
    }
    if (!result) break;
}

Console.WriteLine(result ? "Yes" : "No");