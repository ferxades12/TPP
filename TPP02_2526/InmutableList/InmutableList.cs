namespace InmutableList;

public class InmutableList
{
    private readonly object[] arr;

    public int Count
    {
        get
        {
            return arr.Length;
        }
    }


    public InmutableList()
    {
        arr = [];
    }

    private InmutableList(object[] arr)
    {
        this.arr = arr;
    }

    public InmutableList Add(object item)
    {
        object[] nuevo = new object[Count + 1];
        Array.Copy(arr, nuevo, Count);
        nuevo[Count] = item;

        return new InmutableList(nuevo);
    }

    public object ElementAt(int index)
    {
        return arr[index];
    }

    public InmutableList Set(int index, object item){
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();
            
        object[] nuevo = new object[Count];
        Array.Copy(arr, nuevo, Count);
        nuevo[index] = item;

        return new InmutableList(nuevo);    
    }  
    public InmutableList Insert(int index, object item){
        if (index < 0 || index > Count)
            throw new IndexOutOfRangeException();
    
        object[] nuevo = new object[Count + 1];
        Array.Copy(arr, 0, nuevo, 0, index);
        nuevo[index] = item;
        Array.Copy(arr, index, nuevo, index + 1, Count - index);

        return new InmutableList(nuevo);
    }

    public bool Contains(object item){
        foreach(object ob in arr){
            if (Equals(item, ob)){
                return true;
            }
        }

        return false;
    }

    public InmutableList Remove(object item){        
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (Equals(arr[i], item))
            {
                index = i;
                break;
            }
        }
        if (index == -1) return this;
        return RemoveAt(index);
    }

    public InmutableList RemoveAt(int index){
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();
            
        object[] nuevo = new object[arr.Length - 1];

        Array.Copy(arr, 0, nuevo, 0, index); 
        Array.Copy(arr, index + 1, nuevo, index, arr.Length - index - 1); 

        return new InmutableList(nuevo);
    }

    public InmutableList Clear()
    {
        return new InmutableList();
    }
}
