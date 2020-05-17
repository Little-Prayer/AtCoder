using System;
using System.Collections.Generic;

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var ab = new double[N, 2];
            for (int i = 0; i < N; i++)
            {
                var read = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
                ab[i, 0] = read[0];
                ab[i, 1] = read[1];
            }
            long MOD = 1000000007;

            var ratio = new ElementCounter<double>();
            for (int i = 0; i < N; i++) ratio.Add((double)ab[i, 0] / (double)ab[i, 1]);
            long result = 0;
            for (int i = 0; i < N; i++)
            {
                result += modPow(2, N - ratio[-1 * (double)ab[i, 1] / (double)ab[i, 0]] - i - 1, MOD);
                result %= MOD;
                ratio.Remove((double)ab[i, 0] / (double)ab[i, 1]);
            }
            Console.WriteLine(result - 1);
        }
        static long modPow(long a, long n, long mod)
        {
            long result = 1;
            while (n > 0)
            {
                if ((n & 1) > 0) result = result * a % mod;
                a = a * a % mod;
                n >>= 1;
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
