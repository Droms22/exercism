public class Deque<T>
{
    private Node<T> Head = null;
    
    private class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
    }
    
    public void Push(T value)
    {
        if (Head is null)
        {
            Head = new Node<T>(){ Value = value, Prev = null, Next = null };
            return;
        }

        var current = Head;

        while (current.Next is not null)
            current = current.Next;

        current.Next = new Node<T>()
        {
          Value = value,
          Prev = current,
          Next = null
        };
    }

    public T Pop()
    {
        var current = Head;

        while (current.Next is not null)
            current = current.Next;

        if (current.Prev is not null)
            current.Prev.Next = null;
        
        return current.Value;
    }

    public void Unshift(T value)
    {
        var prevHead = Head;

        Head = new Node<T>()
        {
          Value = value,
          Prev = null,
          Next = prevHead
        };
    }

    public T Shift()
    {
        var value = Head.Value;

        Head = Head.Next;
        
        return value;
    }
}