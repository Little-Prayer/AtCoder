using System;

class Deque<T>
{
    T[] buffer;
    int capacity, count, front;

    public Deque(int _capacity){buffer = new T[capacity = _capacity];}
    public Deque(){buffer = new T[capacity = 16];}

    public void PushFront(T item)
    {

    }
    public void PushBack(T item)
    {

    }
    public T PopFront()
    {

    }
    public T PopBack()
    {

    }

    private void extend()
    {
        
    }
}