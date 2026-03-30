namespace SortedList;

public class SortedList
{
    private LinkedList list;

    public SortedList()
    {
        list = new LinkedList();
    }

    public int Count
    {
        get { return list.Count; }
    }

    public void Add(IComparable? item)
    {
        if (item == null)
        {
            list.Add(item);
            return;
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (item.CompareTo(ElementAt(i)) < 0)
            {
                list.Insert(i, item);
                return;
            }
        }

        list.Add(item);
    }

    public object? ElementAt(int index)
    {
        if (index < 0 || index >= list.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        return list.ElementAt(index);
    }

    public bool Contains(object? item)
    {
        return list.Contains(item);
    }

    public bool Remove(object? item)
    {
        return list.Remove(item);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= list.Count)
            throw new ArgumentOutOfRangeException(nameof(index));

        list.RemoveAt(index);
    }

    public void Clear()
    {
        list.Clear();
    }
}
