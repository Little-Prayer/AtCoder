using System;
using System.Collections.Generic;

namespace ABC121_C___Energy_Drink_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
            var N = read[0];
            var M = read[1];
            var shops = new PriorityQueue<Shop>(true);

            for(int i = 0 ; i < N ; i++)
            {
                read = Array.ConvertAll(Console.ReadLine().Split(' '),long.Parse);
                shops.Push(new Shop(read[0],read[1]));
            }

            Shop currentShop  = currentShop = shops.Pop();
            long amount = 0;
            while(shops.Count() > 0)
            {
                if(currentShop.stock > M) break;
                M -= currentShop.stock;
                amount += currentShop.price * currentShop.stock;
                currentShop = shops.Pop();
            }
            amount += currentShop.price * M;

            Console.WriteLine(amount);
        }
    }
    class Shop : IComparable
    {
        public long price{get;set;}
        public long stock{get;set;}

        public int CompareTo(object _shop)
        {
            Shop shop = (Shop)_shop;
            if(this.price < shop.price) return -1;
            if(this.price > shop.price) return 1;
            if(this.price == shop.price) return 0;
            return 0;
        }
        public Shop(long _price,long _stock)
        {
            this.price = _price;
            this.stock = _stock;
        }
    }

    class PriorityQueue<T> where T : IComparable
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
        this.nodes[0] = this.nodes[nodes.Count-1];
        this.nodes.RemoveAt(nodes.Count-1);
        int root = 0;
        while(root*2 + 1 < this.nodes.Count)
        {
            int child = root * 2 + 1;
            if(child+1<this.nodes.Count && compare(this.nodes[child+1],this.nodes[child]) > 0) child += 1;
            if(compare(this.nodes[child],this.nodes[root]) > 0)
            {
                swap(child,root);
                root = child;
            }else{
                break;
            }
        }
        return returnNode;
    }
    public void Push(T t)
    {
        this.nodes.Add(t);
        var addPosition = nodes.Count - 1;
        while(addPosition > 0)
        {
            var parent = (int)(addPosition-1)/2;
            if(compare(nodes[addPosition],nodes[parent]) > 0 )
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
        T temp = nodes[x];
        nodes[x] = nodes[y];
        nodes[y] = temp;
    }
}
}
