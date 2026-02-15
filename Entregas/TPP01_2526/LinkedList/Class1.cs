namespace LL;

public class Node
{
    public Object Data {get; set;}
    public Node Next {get; set;}

    public Node(Object data)
    {
        Data = data;
    }
}


public class LinkedList
{
    private Node head;

    public int Count {get; private set;}
    /* No entiendo si quieres que se calcule al llamar al get y no haya set (ineficiente) o que solo sea publico el get
    {
        get
        {
            if (head == null) return 0;

            Node current = head;
            int i = 1;

            while(true)
            {
                if (current.Next == null) return i;
                current = current.Next;
                i++;
            }
        }
    } */

    public void Add(Object item)
    {
        Node newNode = new Node(item);

        int count = Count;

        if(count == 0)
        {
            head = newNode;
            Count++;
            return;
        }
        else
        {
            Node current = this.NodeAt(count - 1);
            current.Next = newNode;
            Count++;
        }
    }

    public Object ElementAt(int index)
    {
        return NodeAt(index).Data;
    }

    private Node NodeAt(int index){
        if (head == null || index < 0){throw new IndexOutOfRangeException();}

        Node current = head;

        for(int i = 0; i < index; i++)
        {
            if (current.Next == null){throw new IndexOutOfRangeException("Tried to access a null Next");}
            current = current.Next;
        }

        return current;
    }

    public void Set(int index, Object item)
    {
        Node targetNode = this.NodeAt(index);
        targetNode.Data = item;
    }

    public void Insert(int index, Object item)
    {
        if (index < 0 || index > Count) throw new IndexOutOfRangeException();

        Node newNode = new Node(item);

        if (index == 0){
            newNode.Next = head;
            head = newNode;
        }else{
            Node previousNode = this.NodeAt(index - 1);
            newNode.Next = previousNode.Next;
            previousNode.Next = newNode;
        }

        Count++;
    }

    public bool Contains(Object item)
    {
        if (head == null){return false;}

        Node current = head;

        while(true)
        {
            if (Object.Equals(item, current.Data))
            {
                return true;
            }

            if(current.Next == null)
            {
                return false;
            }

            current = current.Next;
        }
    }

    public bool Remove(Object item)
    {
        if (head == null){return false;}

        if (Object.Equals(item, head.Data))
        {
            head = head.Next;
            Count--;
            return true;
        }

        Node current = head;

        while(true)
        {
            if(current.Next == null)
            {
                return false;
            }

            if (Object.Equals(item, current.Next.Data))
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
        if (index == 0){
            if (head == null) throw new IndexOutOfRangeException();
            head = head.Next;
        } else {
            Node previousNode = this.NodeAt(index - 1);
            if (previousNode.Next == null) throw new IndexOutOfRangeException();
            previousNode.Next = previousNode.Next.Next;
        }

        Count--;
    }

    public void Clear()
    {
        head = null;
        Count = 0;
    }
}
