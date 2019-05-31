using System;
using System.Collections.Generic;

class Deque<T>
{
    T[] buffer;
    int capacity, count, front;

    public Deque(int _capacity){buffer = new T[capacity = 1 << _capacity];}
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
            Array.Copy(buffer,front,newBuffer,0,capacity - front);
            Array.Copy(buffer,0,newBuffer,capacity-front,count-capacity+front);
        }else{
            Array.Copy(buffer,front,newBuffer,0,count);
        }
        return ret;
    }
}