using System;
using System.Collections.Generic;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var ec = new ElementCounter<string>();
            var N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++) ec.Add(Console.ReadLine());

            var max = 0L;
            string result = "";
            foreach (var key in ec.Dic.Keys)
            {
                if (max < ec.Dic[key])
                {
                    result = key;
                    max = ec.Dic[key];
                }
            }
            Console.WriteLine(result);
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
