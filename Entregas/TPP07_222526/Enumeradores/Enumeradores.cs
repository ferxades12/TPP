namespace Enumeradores;

public class Enumeradores
{
    public static IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> secuencia, Func<T1, T2> funcion)
    {
        IList<T2> secuenciaResultante = new List<T2>();

        foreach (T1 elemento in secuencia)
        {
            T2 transformado = funcion(elemento);
            secuenciaResultante.Add(transformado);
        }
        return secuenciaResultante;
    }

    public static IEnumerable<T1> Filter<T1>(IEnumerable<T1> secuencia, Predicate<T1> funcion)
    {
        IList<T1> secuenciaResultante = new List<T1>();

        foreach (T1 elemento in secuencia)
        {
            if (funcion(elemento))
            {
                secuenciaResultante.Add(elemento);
            }
        }
        return secuenciaResultante;
    }

    public static T2 Reduce<T1, T2>(
        IEnumerable<T1> secuencia,
        Func<T1, T2, T2> funcion,
        T2 valorInicial
    )
    {
        T2 acc = valorInicial;

        foreach (T1 elemento in secuencia)
        {
            acc = funcion(elemento, acc);
        }
        return acc;
    }

    public static IEnumerable<T3> Zip<T1, T2, T3>(
        IEnumerable<T1> secuencia1,
        IEnumerable<T2> secuencia2,
        Func<T1, T2, T3> funcion
    )
    {
        IList<T3> secuenciaResultante = new List<T3>();

        using (var e1 = secuencia1.GetEnumerator())
        using (var e2 = secuencia2.GetEnumerator()){
            while (e1.MoveNext() && e2.MoveNext())
                secuenciaResultante.Add(funcion(e1.Current, e2.Current));
        }

        return secuenciaResultante;
    }

}
