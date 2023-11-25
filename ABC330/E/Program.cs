var NQ = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);
var N = NQ[0]; var Q = NQ[1];
var A = Array.ConvertAll(Console.ReadLine()!.Split(' '), int.Parse);

var count = new int[100000];
foreach (int c in A)
{
    if (c < 1000000)
        count[c]++;
}
var mex = -1;
for (int i = 0; i < count.Length; i++)
{
    if (count[i] == 0)
    {
        mex = i;
        break;
    }
}

for(int query=0;query<Q;query++)
{
    var ix = Array.ConvertAll(Console.ReadLine()!.Split(' '),int.Parse);
    var i = ix[0]-1;var x = ix[1];
    if(A[i]<100000)
    {
        if(mex==A[i])
        {
            while(true)
            {
                mex++;
                if(count[mex]==0)
                {
                    break;
                }
            }
        }
        else if(mex>x)
        {
            mex = x;
        }
        count[A[i]]--;
    }
    A[i] = x;
    Console.WriteLine(mex);
}