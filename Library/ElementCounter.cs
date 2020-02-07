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
}