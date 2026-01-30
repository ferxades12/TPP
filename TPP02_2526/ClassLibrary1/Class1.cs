namespace testing;

public class Pila
{
    int[] pila;
    public Pila(int capacidad)
    {
        _capacidad = capacidad;
        pila = new int[capacidad];
    }

    public int Count { get; set; }
    private int _capacidad;
    public int Capacidad { get{ return _capacidad;}}

    public int Pop()
    {
        if (Count == 0) throw new InvalidOperationException("No puedes hacer pop en una pila vacia");
        return pila[--Count];
    }

    public void Push(int v)
    {
        if (Count == Capacidad) throw new InvalidOperationException("No puedes hacer pop en una pila vacia");
        pila[Count++] = v; 
    }

    public bool Contains(int v)
    {
        foreach(int i in pila)
        {
            if (i == v) return true;
        }

        return false;
    }
}
