using System;
using System.Collections.Generic;
using System.Linq;

namespace D___equeue
{
    class Program
    {
        static void Main(string[] args)
        {
            var read = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var N = read[0];
            var K = read[1];
            var V = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            var sumMax = 0;
            
            for(int pickTimes = 1 ; pickTimes <= Math.Min(N,K) ; pickTimes++)
            {
                for(int pickLeft = 0 ; pickLeft <= pickTimes ; pickLeft++)
                {
                    var deque = new Deque<int>(V);
                    var atHand = new List<int>();
                    for(int l = 1 ; l <= pickLeft ; l++) atHand.Add(deque.PopFront());
                    for(int r = 1 ; r <= pickTimes - pickLeft ; r++) atHand.Add(deque.PopBack());

                    atHand.Sort();

                    for(int trash = 0 ; trash < Math.Min(K - pickTimes,pickTimes);trash++)
                    {
                        if(atHand[trash] < 0)
                        {
                            atHand[trash] = 0;
                        }
                        else{
                            break;
                        }
                    }
                    sumMax = Math.Max(sumMax,atHand.Sum());
                }


            }
            Console.WriteLine(sumMax);
        }
    }
    class Deque<T>
{
    T[] buffer;
    int capacity, count, front;

    public Deque(int _capacity){buffer = new T[capacity = _capacity];}
    public Deque(){buffer = new T[capacity = 16];}
    public Deque(T[] items)
    {
        buffer = items;
        capacity = items.Length;
        count = items.Length;
    }

    public void PushFront(T item)
    {
        if(capacity == count) extend();
        count += 1;
        if(front == 0) front = capacity;
        front -= 1;
        buffer[front] = item;
    }
    public void PushBack(T item)
    {
        if(capacity == count) extend();
        count += 1;
        buffer[(front + count -1) % capacity] = item;
    }
    public T PopFront()
    {
        if(count == 0) throw new InvalidOperationException("collection is empty");
        var ret = buffer[front];
        front = front + 1 % capacity;
        count -= 1;
        return ret;
    }
    public T PopBack()
    {
        if(count == 0) throw new InvalidOperationException("collection is empty");
        var ret = (front + count - 1) % capacity;
        count -= 1;
        return buffer[ret];
    }

    private void extend()
    {
        var newBuffer = new T[capacity << 1];
        if(front + count > capacity)
        {
            Array.Copy(buffer,front,newBuffer,0,capacity - front);
            Array.Copy(buffer,0,newBuffer,capacity-front,count-capacity+front);
        }else{
            Array.Copy(buffer,front,newBuffer,0,count);
        }
        buffer = newBuffer;
        front = 0;
        capacity <<= 1;
    }

    public T[] toArray()
    {
        var ret = new T[count];
        if(front + count > capacity)
        {
            Array.Copy(buffer,front,ret,0,capacity - front);
            Array.Copy(buffer,0,ret,capacity-front,count-capacity+front);
        }else{
            Array.Copy(buffer,front,ret,0,count);
        }
        return ret;
    }
}
}
