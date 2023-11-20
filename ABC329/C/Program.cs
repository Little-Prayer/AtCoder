var N = int.Parse(Console.ReadLine()!);
var S = Console.ReadLine()!;

var count = new int[26];

var current = 1;
for (int i = 1; i < N; i++)
{
    if (S[i] == S[i - 1])
    {
        current++;
    }
    else
    {
        if(count[S[i-1]-'a']<current)
        {
            count[S[i - 1] - 'a'] = current;
        }
        current = 1;
    }
}

if (count[S[N - 1] - 'a'] < current)
{
    count[S[N - 1] - 'a'] = current;
}
current = 1;

var result = 0;
for (int i = 0; i < 26; i++) result += count[i];
Console.WriteLine(result);
