using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = long.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            long sum = A.Sum(n => n);
            var counter = new ElementCounter<long>();
            foreach (int a in A) counter.Add(a);

            var dic = counter.Dic;
            var Q = long.Parse(Console.ReadLine());
            for (int i = 0; i < Q; i++)
            {
                var BC = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                var b = BC[0]; var c = BC[1];
                if (dic.ContainsKey(b))
                {
                    sum += dic[b] * (c - b);
                    if (dic.ContainsKey(c))
                    {
                        dic[c] += dic[b];
                        dic[b] = 0;
                    }
                    else
                    {
                        dic.Add(c, dic[b]);
                        dic[b] = 0;
                    }
                }
                Console.WriteLine(sum);
            }
        }
    }

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
}
