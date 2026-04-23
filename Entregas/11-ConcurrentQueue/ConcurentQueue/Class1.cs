namespace ConcurrentQueue;

public class ConcurrentQueue<T>
{
    private GenericLinkedList<T> list;
    private readonly object lockObject = new object();
    public int Count => _count;
    public int _count;

    public ConcurrentQueue()
    {
        list = new GenericLinkedList<T>();
    }

    public bool isEmpty()
    {
        return Interlocked.CompareExchange(ref _count, 0, 0) == 0;
    }

    public void Enqueue(T? value)
    {
        lock (lockObject)
        {
            list.Add(value);

            _count++;
        }
    }

    public T? Dequeue()
    {
        lock (lockObject)
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T? value = list.ElementAt(0);
            list.RemoveAt(0);

            _count--;
            return value;
        }
    }

    public T? Peek()
    {
        lock (lockObject)
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return list.ElementAt(0);
        }
    }
}
