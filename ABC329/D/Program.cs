var NM = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);
var N = NM[0]; var M = NM[1];
var A = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);

var Vote = new int[N + 1];
var currentlyWinner = (0,0);

for (int v = 0; v < M; v++)
{
    Vote[A[v]]++;
    if(currentlyWinner.Item2<Vote[A[v]]||(currentlyWinner.Item2 == Vote[A[v]] && currentlyWinner.Item1 > A[v]))
    {
        currentlyWinner = (A[v], Vote[A[v]]);
    }
    Console.WriteLine(currentlyWinner.Item1);
}
