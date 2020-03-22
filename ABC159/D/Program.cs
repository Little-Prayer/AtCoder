using System;
using System.Collections.Generic;
class ElementCounter<T>
{
    public Dictionary<T, long> Dic;

    public ElementCounter()
    {
        Dic = new Dictionary<T, long>();
    }
    public long this[T key]
    {
        get
        {
            if (Dic.ContainsKey(key))
            {
                return Dic[key];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            if (Dic.ContainsKey(key))
            {
                Dic[key] = value;
            }
            else
            {
                Dic.Add(key, value);
            }
        }
    }
    public void Add(T item)
    {
        if (Dic.ContainsKey(item))
        {
            Dic[item] += 1;
        }
        else
        {
            Dic.Add(item, 1);
        }
    }
    public void Remove(T item)
    {
        if (Dic.ContainsKey(item))
        {
            Dic[item] = Dic[item] != 0 ? Dic[item] - 1 : 0;
        }
    }
}

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);

            var dic = new ElementCounter<long>();
            foreach (long n in A) dic.Add(n);
            long result = 0;
            foreach (long i in dic.Dic.Values) result += i * (i - 1) / 2;
            foreach (long i in A) Console.WriteLine(result - dic[i] + 1);
        }
    }
}
