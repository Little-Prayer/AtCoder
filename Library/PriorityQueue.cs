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
        T returnNode = list(0);
        list(0) = list(list.Count-1);
        list.RemoveAt(list.Count-1);
        int root = 0;
        while(root*2 + 1 < list.Count)
        {
            int child = root * 2 + 1;
            if(compare(list(child+1),list(child)) > 0) child += 1;
            
        }
    }
    public void Push(T t)
    {
        this.list.Add(t);
        var addPosition = list.Count - 1;
        while(addPosition > 0)
        {
            var parent = (int)(addPosition-1)/2;
            if(compare(list(addPosition),list(parent)) > 0 )
            {
                swap(addPosition,parent);
                addPosition = parent;
            }else{
                break;
            }
     }
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