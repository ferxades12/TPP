namespace Generadores;

public class Generadores
{
    public static IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> secuencia, Func<T1, T2> funcion)
    {
        foreach (T1 elemento in secuencia)
        {
            yield return funcion(elemento);
        }
   }
    
    public static IEnumerable<T1> Filter<T1>(IEnumerable<T1> secuencia, Predicate<T1> funcion)
    {
        foreach (T1 elemento in secuencia)
        {
            if (funcion(elemento)){
                yield return elemento;
            }
        }
    }

    public static IEnumerable<T3>  Zip<T1, T2, T3>(IEnumerable<T1> secuencia1, IEnumerable<T2> secuencia2, Func<T1, T2, T3> funcion)
    {
        IEnumerator<T1> e1 = secuencia1.GetEnumerator();
        IEnumerator<T2> e2 = secuencia2.GetEnumerator();
        
        while(e1.MoveNext() && e2.MoveNext())
            yield return funcion(e1.Current, e2.Current);
    }

    public static IEnumerable<T1> Take<T1>(IEnumerable<T1> secuencia, int n)
    {
        int count = 0;
        foreach (T1 elemento in secuencia)
        {
            if (count >= n) yield break;
            yield return elemento;
            count++;
        }
    }

    public static IEnumerable<T1> TakeWhile<T1>(IEnumerable<T1> secuencia, Predicate<T1> funcion)
    {
        foreach (T1 elemento in secuencia)
        {
            if (funcion(elemento)){
                yield return elemento;
            }else{
                return;
            }
        }
    }
    public static IEnumerable<T1> Skip<T1>(IEnumerable<T1> secuencia, int n)
    {
        int i = 1;
        foreach (T1 elemento in secuencia)
        {
            if(i <= n){
                i++;
                continue;
            }
            
            yield return elemento;
            
        }
    }

    public static IEnumerable<T1> SkipWhile<T1>(IEnumerable<T1> secuencia, Predicate<T1> funcion)
    {
        bool skip = true;
        foreach (T1 elemento in secuencia)
        {
            if(skip && funcion(elemento)){
                continue;
            }else{
                skip = false;
            }
            
            yield return elemento;
        
        }
    }
}
