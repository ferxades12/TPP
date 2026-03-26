namespace tpp.lab09;

using System.Linq;

public static class Program
{
    private static Modelo modelo = new Modelo();

    public static void Main()
    {
        // Ejercicio 1
        var consulta1 = modelo.Plataformas.Where(p =>
            p.Peliculas.Any(p => p.Director.Equals("Greta Gerwig"))
        );

        // consulta1 = modelo
        //     .Peliculas.Where(p => p.Director.Equals("Greta Gerwig"))
        //     .Select(p => p.Plataforma)
        //     .Distinct();

        Show(consulta1);

        // Ejercicio 2
        var consulta2 = modelo
            .Peliculas.Where(p => p.Generos.Count() > 1)
            .Select(p => p.Director)
            .Distinct();
        Show(consulta2);

        // Ejercicio 3
        var consulta3 = modelo
            .Valoraciones.Join(
                modelo.Peliculas,
                v => v.IdImdb,
                p => p.IdImdb,
                (v, p) =>
                    new
                    {
                        Titulo = p.Titulo,
                        Fuente = v.Fuente,
                        Puntuacion = v.Puntuacion,
                        Plataforma = p.Plataforma,
                    }
            )
            .Where(x => x.Plataforma.Equals(x.Fuente))
            .OrderBy(x => x.Titulo);
        Show(consulta3);

        // Ejercicio 4
        // var plat = modelo.Plataformas.OrderBy(pl => pl.Nombre);
        // Console.WriteLine("-----------------------------------------------");
        // foreach (var item in plat)
        // {
        //     var duraciones = item.Peliculas.Select(p => p.Duracion);
        //     Console.Write(
        //         item.Nombre
        //             + ";"
        //             + duraciones.Min()
        //             + ";"
        //             + duraciones.Max()
        //             + ";"
        //             + duraciones.Average()
        //     );
        //     Console.WriteLine();
        // }
        var plat = modelo
            .Plataformas.Select(pl => new
            {
                Nombre = pl.Nombre,
                Minima = pl.Peliculas.Min(p => p.Duracion),
                Maxima = pl.Peliculas.Max(p => p.Duracion),
                Promedio = pl.Peliculas.Average(p => p.Duracion),
            })
            .OrderBy(pl => pl.Nombre);

        Console.WriteLine("-----------------------------------------------");
        foreach (var item in plat)
        {
            Console.WriteLine($"{item.Nombre};{item.Minima};{item.Maxima};{item.Promedio}");
        }

        // Ejercicio 5
        var consulta5 = modelo
            .Peliculas.Where(p => p.FechaEstreno.Year >= 2010)
            .Join(
                modelo.Valoraciones,
                p => p.IdImdb,
                v => v.IdImdb,
                (p, v) => new { Director = p.Director, Votos = v.Votos }
            )
            .GroupBy(
                x => x.Director,
                x => x.Votos,
                (d, v) => new { Director = d, SumaVotos = v.Sum() }
            );
        Show(consulta5);

        // Ejercicio 6
        var media = modelo.Peliculas.Select(p => p.Duracion).Average();
        var consulta6 = modelo
            .Peliculas.Where(p => p.Duracion > media)
            .Select(p => new { Titulo = p.Titulo, Duracion = p.Duracion });
        Show(consulta6);
    }

    static void Show<T>(IEnumerable<T> secuencia)
    {
        Console.WriteLine("-----------------------------------------------");
        foreach (var elemento in secuencia)
            Console.WriteLine(elemento);
        Console.WriteLine();
    }
}
