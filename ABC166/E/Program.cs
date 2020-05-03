using System;
using System.Linq;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var reverseA = A.Reverse().ToArray();
            long result = 0;
            for (int i = 0; i < N; i++) A[i] = A[i] - i;
            var counter1 = new ElementCounter<long>();
            foreach (long a in A) counter1.Add(a);
            foreach (long k in counter1.Dic.Keys)
            {
                if (k <= 0) continue;
                if (counter1.Dic.ContainsKey(-k)) result += counter1.Dic[k] * counter1.Dic[-k];
            }
            for (int i = 0; i < N; i++) reverseA[i] = reverseA[i] - i;
            var counter2 = new ElementCounter<long>();
            foreach (long a in reverseA) counter2.Add(a);
            foreach (long k in counter2.Dic.Keys)
            {
                if (k <= 0) continue;
                if (counter2.Dic.ContainsKey(-k)) result += counter2.Dic[k] * counter2.Dic[-k];
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
