using System;
using System.Collections.Generic;
using System.Linq;

namespace ABC146_E___Rem_of_Sum_is_Num
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solver());
        }
        static long solver()
        {
            var NK = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var N = NK[0]; var K = NK[1];
            if (K == 1) return 0;

            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var minus1A = A.Select(n => n - 1).ToArray();
            var accumA = new long[N + 1];
            accumA[0] = 0;
            for (int i = 1; i < N + 1; i++) accumA[i] = accumA[i - 1] + minus1A[i - 1];
            accumA = accumA.Select(n => n % K).ToArray();

            var dic = new ElementCounter<long>();
            for (int i = 1; i < Math.Min(K, N + 1); i++) dic.Add(accumA[i]);

            var result = 0L;
            result += dic[0];
            for (int i = 1; i < N + 1; i++)
            {
                dic.Remove(accumA[i]);
                if (N >= i + K - 1) dic.Add(accumA[i + K - 1]);

                result += dic[accumA[i]];
            }
            return result;
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
