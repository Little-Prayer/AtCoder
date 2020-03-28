using System;
using System.Linq;
using System.Collections.Generic;
class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> nodes;
    private Boolean isAsc;

    public PriorityQueue(Boolean _isAsc)
    {
        this.nodes = new List<T>();
        this.isAsc = _isAsc;
    }

    public int Count()
    {
        return this.nodes.Count;
    }
    public T Pop()
    {
        T returnNode = this.nodes[0];
        this.nodes[0] = this.nodes[nodes.Count - 1];
        this.nodes.RemoveAt(nodes.Count - 1);
        int root = 0;
        while (root * 2 + 1 < this.nodes.Count)
        {
            int child = root * 2 + 1;
            if (child + 1 < this.nodes.Count && compare(this.nodes[child + 1], this.nodes[child]) > 0) child += 1;
            if (compare(this.nodes[child], this.nodes[root]) > 0)
            {
                swap(child, root);
                root = child;
            }
            else
            {
                break;
            }
        }
        return returnNode;
    }
    public T Top()
    {
        return this.nodes[0];
    }
    public void Push(T t)
    {
        this.nodes.Add(t);
        var addPosition = nodes.Count - 1;
        while (addPosition > 0)
        {
            var parent = (int)(addPosition - 1) / 2;
            if (compare(nodes[addPosition], nodes[parent]) > 0)
            {
                swap(addPosition, parent);
                addPosition = parent;
            }
            else
            {
                break;
            }
        }
    }
    private int compare(T x, T y)
    {
        return this.isAsc ? y.CompareTo(x) : x.CompareTo(y);
    }
    private void swap(int x, int y)
    {
        T temp = nodes[x];
        nodes[x] = nodes[y];
        nodes[y] = temp;
    }
}

namespace E
{
    class Program
    {
        static void Main(string[] args)
        {
            var XYABC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var X = XYABC[0]; var Y = XYABC[1]; var A = XYABC[2]; var B = XYABC[3]; var C = XYABC[4];
            var P = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();
            var Q = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();
            var R = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse).OrderByDescending(n => n).ToArray();

            var red = new PriorityQueue<long>(true);
            var green = new PriorityQueue<long>(true);
            for (int i = 0; i < X; i++) red.Push(P[i]);
            for (int i = 0; i < Y; i++) green.Push(Q[i]);
            for (int i = 0; i < C; i++)
            {
                if (red.Top() > green.Top())
                {
                    if (green.Top() < R[i])
                    {
                        green.Pop();
                        green.Push(R[i]);
                    }
                }
                else
                {
                    if (red.Top() < R[i])
                    {
                        red.Pop();
                        red.Push(R[i]);
                    }
                }

            }

            var result = 0L;
            while (green.Count() > 0) result += green.Pop();
            while (red.Count() > 0) result += red.Pop();
            Console.WriteLine(result);
        }
    }
}
