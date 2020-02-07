using System.Collections.Generic;
class ElementCounter<T>
{
    public Dictionary<T, long> dic;

    public ElementCounter()
    {
        dic = new Dictionary<T, long>();
    }
    public long this[T key]
    {
        get
        {
            return dic[key];
        }
        set
        {
            if (dic.ContainsKey(key))
            {
                dic.Add(key, value);
            }
            else
            {
                dic[key] = value;
            }
        }
    }
    public void Add(T item)
    {
        if (dic.ContainsKey(item))
        {
            dic.Add(item, 0);
        }
        else
        {
            dic[item] += 1;
        }
    }
}