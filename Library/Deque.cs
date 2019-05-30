using System;

class Deque<T>
{
    T[] buffer;
    int capacity, count, front;

    public Deque(int _capacity)
    {
        capacity = _capacity;
        count = 0;
        front = 0;
        buffer = new T[capacity];
    }
}