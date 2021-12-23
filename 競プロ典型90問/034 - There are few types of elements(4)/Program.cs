using System;
using System.Collections.Generic;

namespace _034___There_are_few_types_of_elements_4_
{
    class Program
    {
        static void Main(string[] args)
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var result = 0;

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
}
