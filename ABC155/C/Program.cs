using System;
using System.Collections.Generic;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var words = new string[N];
            for (int i = 0; i < N; i++)
            {
                var word = Console.ReadLine();
                words[i] = word;
            }
            Array.Sort(words);
            var count = new List<string>[200001];
            for (int i = 0; i < count.Length; i++) count[i] = new List<string>();
            var c = 1;
            var max = 0;
            for (int i = 1; i < N; i++)
            {
                if (words[i] != words[i - 1])
                {
                    count[c].Add(words[i - 1]);
                    c = 1;
                }
                else
                {
                    c++;
                    max = Math.Max(max, c);
                }
            }
            count[c].Add(words[N - 1]);

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
