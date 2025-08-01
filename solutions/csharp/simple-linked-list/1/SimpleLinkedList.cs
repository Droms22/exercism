using System.Collections;
using System.Diagnostics.CodeAnalysis;

public class SimpleLinkedList<T>: IEnumerable<T>
{
    public Node<T>? Head { get; private set; }
    public int Count { get; private set; }

    public SimpleLinkedList() { }
    public SimpleLinkedList(T value) => Push(value);
    public SimpleLinkedList(IEnumerable<T> values)
    {
        foreach (var value in values)
        {
            Push(value);
        }
    }

    public void Push(T value)
    {
        var node = new Node<T>(value);
        node.Next = Head;
        Head = node;
        Count++;
    }

    public T Pop()
    {
        if (Head is null)
            return Head!.Value;

        var value = Head.Value;
        Head = Head.Next;
        Count--;

        return value;
    }

    public void Reverse()
    {
        Node<T>? prev, curr, next;

        prev = null;
        curr = Head;

        while (curr is not null)
        {
            next = curr.Next;
            curr.Next = prev;
            prev = curr;
            curr = next;
        }

        Head = prev;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var curr = Head;
        while (curr is not null)
        {
            T value = curr.Value;
            curr = curr.Next;
            yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; } = null;

    public Node(T value) => Value = value;
}