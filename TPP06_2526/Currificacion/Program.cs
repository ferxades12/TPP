namespace lab06;

class Program
{
    static void Main()
    {

        // No currificada vs currificada
        bool res1 = StartsWith("pe", "perezoso");
        Console.WriteLine($"\"StartsWith(pe, perezoso)\": { res1 }");

        bool res2 = CurriedStartsWith("pe")("perezoso");
        Console.WriteLine($"CurriedStartsWith(\"pe\")(\"perezoso\"): { res2 }");

        // ¿Qué estámos usando aquí?
        var EsUrlSegura = CurriedStartsWith("https://");
        Console.WriteLine($"¿Es segura https://uniovi.es ? {EsUrlSegura("https://uniovi.es")}");
        Console.WriteLine($"¿Es segura http://uniovi.es ? {EsUrlSegura("http://uniovi.es")}");

        Console.WriteLine($"EstaEnRango(0, 10, 5): {EstaEnRango(0, 10, 5)}");

        // Empleando la anterior, crea "EstaEnEdadLaboral" [16, 67]
        var EstaEnEdadLaboral = EstaEnRagnoCurri(16, 67);

    }

    static bool StartsWith(string prefijo, string texto)
    {
        return texto.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase);
    }

    static Func<string, bool> CurriedStartsWith(string prefijo)
    {
        return texto => texto.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase);
    }

    static bool EstaEnRango(int min, int max, int x)
    {
        return x >= min && x <= max;
    }

    // Implementa la versión currificada de EstaEnRango
    static Func<int, bool> EstaEnRagnoCurri(int min, int max){
        return x => EstaEnRango(min, max, x);
    }
    static Func<int, Func<int, bool>> EstaEnRagnoCurritriple(int min){
        return max => EstaEnRagnoCurri(min, max);
    }
}
