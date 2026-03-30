using System.Collections;

namespace GenericLinkedList;

internal class Node<T>
{
    public T? Data { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T? data)
    {
        Data = data;
    }
}

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T>? head;

    public int Count { get; private set; }

    public void Add(T? item)
    {
        Node<T>? newNode = new Node<T>(item);

        int count = Count;

        if (count == 0)
        {
            head = newNode;
            Count++;
            return;
        }
        else
        {
            Node<T> current = this.NodeAt(count - 1);
            current.Next = newNode;
            Count++;
        }
    }

    public T? ElementAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();

        return NodeAt(index).Data;
    }

    private Node<T> NodeAt(int index)
    {
        if (head == null || index < 0 || index >= Count)
            throw new IndexOutOfRangeException();

        Node<T> current = head;

        for (int i = 0; i < index; i++)
        {
            if (current.Next == null)
            {
                throw new IndexOutOfRangeException("Tried to access a null Next");
            }
            current = current.Next;
        }

        return current;
    }

    public void Set(int index, T? item)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();

        Node<T> targetNode = this.NodeAt(index);
        targetNode.Data = item;
    }

    public void Insert(int index, T? item)
    {
        if (index < 0 || index > Count)
            throw new IndexOutOfRangeException();

        Node<T> newNode = new Node<T>(item);

        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node<T> previousNode = this.NodeAt(index - 1);
            newNode.Next = previousNode.Next;
            previousNode.Next = newNode;
        }

        Count++;
    }

    public bool Contains(T? item)
    {
        if (head == null)
        {
            return false;
        }

        Node<T> current = head;

        while (true)
        {
            if (Equals(item, current.Data))
            {
                return true;
            }

            if (current.Next == null)
            {
                return false;
            }

            current = current.Next;
        }
    }

    public bool Remove(T? item)
    {
        if (head == null)
        {
            return false;
        }

        if (Equals(item, head.Data))
        {
            head = head.Next;
            Count--;
            return true;
        }

        Node<T> current = head;

        while (true)
        {
            if (current.Next == null)
            {
                return false;
            }

            if (Equals(item, current.Next.Data))
            {
                current.Next = current.Next.Next;
                Count--;
                return true;
            }

            current = current.Next;
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            if (head == null)
                throw new IndexOutOfRangeException();
            head = head.Next;
        }
        else
        {
            Node<T> previousNode = this.NodeAt(index - 1);
            if (previousNode.Next == null)
                throw new IndexOutOfRangeException();
            previousNode.Next = previousNode.Next.Next;
        }

        Count--;
    }

    public void Clear()
    {
        head = null;
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new LLEnumerator<T>(head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

internal class LLEnumerator<T> : IEnumerator<T>
{
    private Node<T>? head;
    private Node<T>? current;
    private bool started;

    public LLEnumerator(Node<T>? head)
    {
        this.head = head;
        this.current = null;
        this.started = false;
    }

    public T? Current
    {
        get
        {
            if (!started || current == null)
                throw new InvalidOperationException();
            return current.Data;
        }
    }

    object? IEnumerator.Current
    {
        get { return Current; }
    }

    public bool MoveNext()
    {
        if (!started)
        {
            current = head;
            started = true;
        }
        else if (current != null)
        {
            current = current.Next;
        }
        return current != null;
    }

    public void Reset()
    {
        current = null;
        started = false;
    }

    public void Dispose() { }
}
