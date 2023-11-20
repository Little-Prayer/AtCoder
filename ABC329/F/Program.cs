var NQ = Array.ConvertAll(Console.ReadLine()!.Split(' '),int.Parse);
var N = NQ[0];var Q = NQ[1];
var C = Array.ConvertAll(Console.ReadLine()!.Split(' '),int.Parse);

var boxes = new HashSet<int>[N + 1];
for (int i = 1; i <= N; i++)
{
    boxes[i] = new HashSet<int>
    {
        C[i - 1]
    };
}

for(int query=0;query<Q;query++)
{
    var ab = Array.ConvertAll(Console.ReadLine()!.Split(' '),int.Parse);
    var a = ab[0];var b=ab[1];

    boxes[b].UnionWith(boxes[a]);
    boxes[a].Clear();
    Console.WriteLine(boxes[b].Count);
}
