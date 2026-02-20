namespace Transacciones;






/// <summary>
/// Funciones de orden superior: Map, Filter, Reduce y Zip.
/// class vs record y uso de with
/// </summary>
public class Program
{


    /// <summary>
    /// Map es una función de orden superior que transforma uno a uno los elementos de una secuencia
    /// </summary>
    /// <typeparam name="T1">Tipo de la secuencia de entrada</typeparam>
    /// <typeparam name="T2">Tipo de la secuencia de salida</typeparam>
    /// <param name="secuencia">Secuencia de entrada</param>
    /// <param name="funcion">La función que transforma un elemento de T1 en un elemento de T2</param>
    /// <returns></returns>

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
            if (funcion(elemento)){
                secuenciaResultante.Add(elemento);
            }
        }
        return secuenciaResultante;
    }

    public static T2? Reduce<T1, T2>(IEnumerable<T1> secuencia, Func<T1, T2?, T2> funcion)
    {
        IList<T1> secuenciaResultante = new List<T1>();
        T2? acc = default;

        foreach (T1 elemento in secuencia)
        {
            acc = funcion(elemento, acc);
        }
        return acc;
    }
    
    public static IEnumerable<T3>  Zip<T1, T2, T3>(IEnumerable<T1> secuencia1, IEnumerable<T2> secuencia2, Func<T1, T2, T3> funcion)
    {
        IList<T3> secuenciaResultante = new List<T3>();

        IEnumerator<T1> e1 = secuencia1.GetEnumerator();
        IEnumerator<T2> e2 = secuencia2.GetEnumerator();
        
        while(e1.MoveNext() && e2.MoveNext())
            secuenciaResultante.Add(funcion(e1.Current, e2.Current));
        
        return secuenciaResultante;
    }


    public static void Main()
    {

        EjemplosImperativos();
        // EjercicioTransacciones();
        // EjercicioZip();
    }

    public static void EjemplosImperativos()
    {
        int[] valores = { 1, 2, 3, 4, 5, 6 };
        
        // Ejemplo 1.

        IList<double> resultante = new List<double>();
        // Iteración del origen
        foreach(var v in valores)
        {
            // Operación de transformación de cada elemento
            double mitad = v / 2.0;

            // Almacenamiento o emisión del elemento resultante
            resultante.Add(mitad);
        }

        Console.WriteLine("La mitad de cada elemento:");
        foreach(var v in resultante)
            Console.WriteLine(v);

        // Ejemplo 2.

        IList<double> resultante2 = new List<double>();
        foreach(var v in valores)
        {
            if (v % 2 == 0)
                resultante2.Add(v);
        }
        Console.WriteLine("Los pares:");
        foreach(var v in resultante2)
            Console.WriteLine(v);
        
        resultante2 = Filter<int>(valores, v => v % 2 == 0);

        // Ejemplo 3.

        int suma = 0;
        foreach(var v in valores)
            suma += v;
        Console.WriteLine($"La suma: {suma}");        
    }


    public static void EjercicioTransacciones()
    {
        var historicoVentas = new List<Venta>
            {
                new Venta { Region = "Europa",      Estado = Estado.Cancelada, Cantidad = 100m },
                new Venta { Region = "Asia", Estado = Estado.Confirmada,  Cantidad = 500m },
                new Venta { Region = "Europa",      Estado = Estado.Cancelada, Cantidad = 200m },
                new Venta { Region = "Asia", Estado = Estado.Cancelada, Cantidad = 300m },
                new Venta { Region = "Europa",      Estado = Estado.Cancelada, Cantidad = 50m },
                new Venta { Region = "Asia", Estado = Estado.Cancelada, Cantidad = 150m },
                new Venta { Region = "Europa",      Estado = Estado.Confirmada,  Cantidad = 120m },
                new Venta { Region = "Asia", Estado = Estado.Cancelada, Cantidad = 800m },
            };

        // Cálculo del beneficio neto en Europa

        // EJERCICIO: Parte a transformar 1.
        decimal totalBeneficioEuropa = 0;
        foreach (var v in historicoVentas)
        {
            if (v.Region.ToLower() == "europa")
            {
                if (v.Estado == Estado.Confirmada)
                {
                    decimal beneficioNeto = v.Cantidad * 0.80m;
                    totalBeneficioEuropa += beneficioNeto;
                }
            }
        }



        Console.WriteLine($"Beneficio neto en Europa: {totalBeneficioEuropa}");


        // Cálculo del beneficio medio.
        decimal total = 0;
        uint recuento = 0;
        foreach (var s in historicoVentas)
        {
            if (s.Estado == Estado.Cancelada)
            {
                continue;
            }
            decimal margen = 0;
            switch (s.Region.ToLower())
            {
                case "europa":
                    margen = 0.80m;
                    break;
                case "asia":
                    margen = 0.60m;
                    break;
                default:
                    throw new Exception("Region desconocida");
            }
            total += s.Cantidad * margen;
            recuento++;
        }
        decimal mediaBeneficio = total / recuento;
        Console.WriteLine($"Beneficio medio: {mediaBeneficio}");        
    }


    /// <summary>
    /// Implementa una función de orden superior Zip que reciba dos secuencias IEnumerable<T> y una función Func<T1, T2, TResult>. 
    /// La función debe recorrer ambas secuencias en paralelo y devolver una nueva secuencia con el resultado de aplicar
    /// la función a cada par de elementos (uno de cada secuencia -> Tupla). 
    /// La iteración termina cuando se agote cualquiera de las dos secuencias.
    /// </summary>
    static void EjercicioZip()
    {
        //Imprímase por pantalla las tuplas resultantes de aplicar Zip a estas dos secuencias.
        var regiones = new List<string> { "Europa", "África", "Asia" };
        var margenes = new List<decimal> { 0.80m, 0.60m, 0.70m };

    }
}
public enum Estado
{
    Cancelada,
    Confirmada
}

public class Venta
{
    public required string Region { get; set; }
    public Estado Estado { get; set; }
    public decimal Cantidad { get; set; }
}
