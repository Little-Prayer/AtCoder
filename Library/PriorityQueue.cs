using System;
using System.Collections.Generic;

class PriorityQueue<T> where T : IComparable
{
    private List<T> list;
    private Boolean isAsc;

    public PriorityQueue(Boolean _isAsc)
    {
        this.list = new List<T>();
        this.isAsc = _isAsc;
    }

    public int Count()
    {
        return this.list.Count;
    }
    public T Pop()
    {
        
    }
    public void Push(T t)
    {

    }
    private int compare(T x,T y)
    {
        return this.isAsc ? y.CompareTo(x) : x.CompareTo(y);
    }
    private void swap(int x,int y)
    {
        T temp = list(x);
        list(x) = list(y);
        list(y) = temp;
    }
}