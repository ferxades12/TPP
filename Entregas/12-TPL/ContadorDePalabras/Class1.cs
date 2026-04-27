namespace ContadorDePalabras;

using System.Diagnostics;
using System.Text;

public class Contador
{
    static void Main(string[] args)
    {
        string dirTexto = Path.GetFullPath("../clarin.txt");

        Console.WriteLine("Contar Secuencial For");
        ContarSecuencialFor(dirTexto);
        Console.WriteLine("------------------------------");

        Console.WriteLine("Contar Paralelo For");
        ContarParaleloFor(dirTexto);
        Console.WriteLine("------------------------------");

        Console.WriteLine("Contar Local For");
        ContarLocalFor(dirTexto);
        Console.WriteLine("------------------------------");

        Console.WriteLine("Contar Paralelo ForEach");
        ContarParaleloForEach(dirTexto);
        Console.WriteLine("------------------------------");

        Console.WriteLine("Contar Local ForEach");
        ContarLocalForEach(dirTexto);
        Console.WriteLine("------------------------------");

        Console.WriteLine("Contar Linq");
        ContarLinq(dirTexto);
        Console.WriteLine("------------------------------");

        Console.WriteLine("Contar Linq Paralelo Malo");
        ContarLinqParaleloMalo(dirTexto);
        Console.WriteLine("------------------------------");

        Console.WriteLine("Contar Linq Paralelo Local");
        ContarLinqParaleloLocal(dirTexto);
        Console.WriteLine("------------------------------");
    }

    static void ContarLinq(string dirTexto)
    {
        Stopwatch sw = Stopwatch.StartNew();

        var reps = LeerPalabrasFichero(dirTexto)
            .GroupBy(palabra => palabra.ToLower())
            .Select(grupo => new { Palabra = grupo.Key, Repeticiones = grupo.Count() })
            .ToList();
        sw.Stop();

        Console.WriteLine(
            $"de {reps.Where(x => x.Palabra == "de").Select(x => x.Repeticiones).First()}"
        );
        Console.WriteLine(sw.Elapsed.TotalSeconds);
    }

    static void ContarSecuencialFor(string dirTexto)
    {
        Stopwatch sw = Stopwatch.StartNew();

        Dictionary<string, int> dic = new Dictionary<string, int>();

        var palabras = LeerPalabrasFichero(dirTexto);

        for (int i = 0; i < palabras.Length; i++)
        {
            string palabra = palabras[i].ToLower();
            if (dic.ContainsKey(palabra))
            {
                dic[palabra]++;
            }
            else
            {
                dic[palabra] = 1;
            }
        }

        sw.Stop();

        Console.WriteLine($"de {dic["de"]}");
        Console.WriteLine($"{sw.Elapsed.TotalSeconds} segundos");
    }

    static void ContarParaleloFor(string dirTexto)
    {
        Stopwatch sw = Stopwatch.StartNew();

        Dictionary<string, int> dic = new Dictionary<string, int>();
        object state = new object();

        var palabras = LeerPalabrasFichero(dirTexto);

        Parallel.For(
            0,
            palabras.Length,
            i =>
            {
                string palabra = palabras[i].ToLower();
                lock (state)
                {
                    if (dic.ContainsKey(palabra))
                    {
                        dic[palabra]++;
                    }
                    else
                    {
                        dic[palabra] = 1;
                    }
                }
            }
        );

        sw.Stop();

        Console.WriteLine($"de {dic["de"]}");
        Console.WriteLine($"{sw.Elapsed.TotalSeconds} segundos");
    }

    static void ContarParaleloForEach(string dirTexto)
    {
        Stopwatch sw = Stopwatch.StartNew();

        Dictionary<string, int> dic = new Dictionary<string, int>();
        object state = new object();

        var palabras = LeerPalabrasFichero(dirTexto);

        Parallel.ForEach(
            palabras,
            palabra =>
            {
                palabra = palabra.ToLower();
                lock (state)
                {
                    if (dic.ContainsKey(palabra))
                    {
                        dic[palabra]++;
                    }
                    else
                    {
                        dic[palabra] = 1;
                    }
                }
            }
        );

        sw.Stop();

        Console.WriteLine($"de {dic["de"]}");
        Console.WriteLine($"{sw.Elapsed.TotalSeconds} segundos");
    }

    static void ContarLocalFor(string dirTexto)
    {
        Stopwatch sw = Stopwatch.StartNew();

        Dictionary<string, int> globalDic = new Dictionary<string, int>();
        object state = new object();

        var palabras = LeerPalabrasFichero(dirTexto);

        Parallel.For(
            0,
            palabras.Length,
            () => new Dictionary<string, int>(),
            (i, loopState, dic) =>
            {
                string palabra = palabras[i].ToLower();
                if (dic.ContainsKey(palabra))
                {
                    dic[palabra]++;
                }
                else
                {
                    dic[palabra] = 1;
                }
                return dic;
            },
            dic =>
            {
                lock (state)
                {
                    foreach (var par in dic)
                    {
                        if (globalDic.ContainsKey(par.Key))
                            globalDic[par.Key] += par.Value;
                        else
                            globalDic[par.Key] = par.Value;
                    }
                }
            }
        );

        // List<KeyValuePair<string, int>> listaOrdenada = new List<KeyValuePair<string, int>>(
        //     globalDic
        // );
        // listaOrdenada.Sort((a, b) => a.Value.CompareTo(b.Value));

        sw.Stop();

        Console.WriteLine($"de {globalDic["de"]}");
        Console.WriteLine($"{sw.Elapsed.TotalSeconds} segundos");
    }

    static void ContarLocalForEach(string dirTexto)
    {
        Stopwatch sw = Stopwatch.StartNew();

        Dictionary<string, int> globalDic = new Dictionary<string, int>();
        object state = new object();

        var palabras = LeerPalabrasFichero(dirTexto);

        Parallel.ForEach(
            palabras,
            () => new Dictionary<string, int>(),
            (palabra, loopState, dic) =>
            {
                palabra = palabra.ToLower();
                if (dic.ContainsKey(palabra))
                {
                    dic[palabra]++;
                }
                else
                {
                    dic[palabra] = 1;
                }
                return dic;
            },
            dic =>
            {
                lock (state)
                {
                    foreach (var par in dic)
                    {
                        if (globalDic.ContainsKey(par.Key))
                            globalDic[par.Key] += par.Value;
                        else
                            globalDic[par.Key] = par.Value;
                    }
                }
            }
        );

        // List<KeyValuePair<string, int>> listaOrdenada = new List<KeyValuePair<string, int>>(
        //     globalDic
        // );
        // listaOrdenada.Sort((a, b) => a.Value.CompareTo(b.Value));

        sw.Stop();

        Console.WriteLine($"de {globalDic["de"]}");
        Console.WriteLine($"{sw.Elapsed.TotalSeconds} segundos");
    }

    static void ContarLinqParaleloMalo(string dirTexto)
    {
        Stopwatch sw = Stopwatch.StartNew();

        var reps = LeerPalabrasFichero(dirTexto)
            .AsParallel()
            .GroupBy(palabra => palabra.ToLower())
            .Select(grupo => new { Palabra = grupo.Key, Repeticiones = grupo.Count() })
            .ToList();
        sw.Stop();

        Console.WriteLine(
            $"de {reps.Where(x => x.Palabra == "de").Select(x => x.Repeticiones).First()}"
        );
        Console.WriteLine(sw.Elapsed.TotalSeconds);
    }

    static void ContarLinqParaleloLocal(string dirTexto)
    {
        Stopwatch sw = Stopwatch.StartNew();

        var reps = LeerPalabrasFichero(dirTexto)
            .AsParallel()
            .Aggregate(
                () => new Dictionary<string, int>(),
                (dic, palabra) =>
                {
                    palabra = palabra.ToLower();
                    if (dic.ContainsKey(palabra))
                    {
                        dic[palabra] += 1;
                    }
                    else
                    {
                        dic[palabra] = 1;
                        ;
                    }

                    return dic;
                },
                (dic1, dic2) =>
                {
                    foreach (var par in dic1)
                    {
                        if (dic2.ContainsKey(par.Key))
                        {
                            dic2[par.Key] += dic1[par.Key];
                        }
                        else
                        {
                            dic2[par.Key] = dic1[par.Key];
                        }
                    }
                    return dic2;
                },
                dic => dic
            )
            .ToList();
        sw.Stop();

        var top = reps.OrderByDescending(x => x.Value).First();
        Console.WriteLine($"{top.Key} {top.Value}");
        Console.WriteLine(sw.Elapsed.TotalSeconds);
    }

    public static string[] LeerPalabrasFichero(string nombreFichero)
    {
        return File.ReadAllLines(nombreFichero)
            .SelectMany(linea =>
                linea.Split(
                    new char[]
                    {
                        ' ',
                        '\r',
                        '\n',
                        ',',
                        '.',
                        ';',
                        ':',
                        '-',
                        '!',
                        '¡',
                        '¿',
                        '?',
                        '/',
                        '«',
                        '»',
                        '_',
                        '(',
                        ')',
                        '\"',
                        '*',
                        '\'',
                        'º',
                        '[',
                        ']',
                        '#',
                    },
                    StringSplitOptions.RemoveEmptyEntries
                )
            )
            .ToArray();
    }
}
