var NLR = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);
var N = NLR[0]; var L = NLR[1]; var R = NLR[2];
var A = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);

for(int i = 0;i<N;i++)
{
    if(A[i]<L)Console.WriteLine(L);
    else if(A[i]>R)Console.WriteLine(R);
    else Console.WriteLine(A[i]);
}