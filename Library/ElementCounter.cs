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