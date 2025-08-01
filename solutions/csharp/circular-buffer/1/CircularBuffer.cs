using System;

public class CircularBuffer<T>
{
    private T[] buffer;
    private int oldest = -1;
    private int current = -1;

    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];
    }

    public T Read()
    {
        if (oldest == -1)
            throw new InvalidOperationException();

        T item = buffer[oldest];
        if (item.Equals(default(T)))
        {
            throw new InvalidOperationException();
        }
        buffer[oldest] = default(T);
        oldest++;
        if (oldest == buffer.Length)
            oldest = 0;        
        return item;
    }

    public void Write(T value)
    {
        current++;

        if (current == buffer.Length)
            current = 0;

        if (!buffer[current].Equals(default(T)))
        {
            throw new InvalidOperationException();
        }

        buffer[current] = value;

        if (oldest == -1)
            oldest++;
    }

    public void Overwrite(T value)
    {
        if (isFull())
        {
            buffer[oldest] = value;
            oldest++;
            if (oldest == buffer.Length)
                oldest = 0;
        }
        else
        {
            current++;
            if (current == buffer.Length)
                current = 0;
    
            buffer[current] = value;
    
            if (oldest == -1)
                oldest++;
        }
    }

    public void Clear()
    {
        for (int i = 0; i < buffer.Length; i++)
        {
            buffer[i] = default(T);
        }
    }

    public bool isFull()
    {
        foreach (var item in buffer)
        {
            if (item.Equals(default(T)))
                return false;
        }
        return true;
    }
}