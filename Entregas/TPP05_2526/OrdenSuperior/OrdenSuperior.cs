namespace OS;
public class Program
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
            if (funcion(elemento)){
                secuenciaResultante.Add(elemento);
            }
        }
        return secuenciaResultante;
    }

    public static T2 Reduce<T1, T2>(IEnumerable<T1> secuencia, Func<T1, T2, T2> funcion, T2 valorInicial)
    {
        T2 acc = valorInicial;

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

public enum Estado {
            Cancelada,
            Confirmada
        }

        public class Venta {
            public required string Region { get; set; }
            public Estado Estado { get; set; }
            public decimal Cantidad { get; set; }
        }

    public static void EjercicioTransacciones() {
        

        var historicoVentas = new List<Venta>
            {
                new() { Region = "Europa",      Estado = Estado.Cancelada, Cantidad = 100m },
                new() { Region = "Asia", Estado = Estado.Confirmada,  Cantidad = 500m },
                new() { Region = "Europa",      Estado = Estado.Cancelada, Cantidad = 200m },
                new() { Region = "Asia", Estado = Estado.Cancelada, Cantidad = 300m },
                new() { Region = "Europa",      Estado = Estado.Cancelada, Cantidad = 50m },
                new() { Region = "Asia", Estado = Estado.Cancelada, Cantidad = 150m },
                new() { Region = "Europa",      Estado = Estado.Confirmada,  Cantidad = 120m },
                new() { Region = "Asia", Estado = Estado.Cancelada, Cantidad = 800m },
                new() { Region = "NorteAmérica", Estado = Estado.Cancelada, Cantidad = 100m},
                new() { Region = "NorteAmérica", Estado = Estado.Confirmada, Cantidad = 200m},
                new() { Region = "NorteAmérica", Estado = Estado.Cancelada, Cantidad = 300m},
                new() { Region = "NorteAmérica", Estado = Estado.Confirmada, Cantidad = 400m},
            };
        
        //EJERCICIO 1. Calcula el número de ventas no confirmadas en Norteamérica.
        int total = Reduce(Filter(historicoVentas, v => Equals(v.Region, "NorteAmérica") && Equals(v.Estado, Estado.Cancelada)), (v, acc) => acc ++, 0);
        Console.WriteLine($"Número de ventas no confirmadas en NA: {total}");


        //EJERCICIO 3. Obtener la región con mayor facturación neta. Devolver nombre e importe de facturación neta
        
        var regiones = new List<string> { "Europa", "África", "Asia", "NorteAmérica" };
        var margenes = new List<decimal> { 0.80m, 0.60m, 0.70m, 0.5m };

        var resultado = Zip(regiones, margenes, (r, m) => {
            var facturacionNeta = Reduce(
                Filter(historicoVentas, v => Equals(v.Region, r) && Equals(v.Estado, Estado.Confirmada)),
           
                (venta, acc) => acc + (venta.Cantidad * m),
                0m
            );
            return (Region: r, FacturacionNeta: facturacionNeta);
        });
        var regionMayorFacturacion = Reduce(
            resultado,
            (actual, acc) => (actual.FacturacionNeta > acc.FacturacionNeta) ? actual : acc,
            (Region: "", FacturacionNeta: 0m)
        );
        Console.WriteLine($"Región con mayor facturación neta: {regionMayorFacturacion.Region}, Importe: {regionMayorFacturacion.FacturacionNeta}");   

    }

    static void Main()
    {
        EjercicioTransacciones();
    }
}
