using LL;

namespace ConsoleLL;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Demostración de LinkedList<T> ===\n");

        // 1. Crear una lista de enteros
        Console.WriteLine("1. Creando una LinkedList<int> y agregando elementos...");
        var lista = new LL.LinkedList<int>();
        lista.Add(10);
        lista.Add(20);
        lista.Add(30);
        lista.Add(40);
        Console.WriteLine($"   Elementos agregados: 10, 20, 30, 40");
        Console.WriteLine($"   Count: {lista.Count}");
        MostrarLista(lista);

        // 2. ElementAt - Acceder a elementos por índice
        Console.WriteLine("\n2. Accediendo a elementos por índice (ElementAt):");
        Console.WriteLine($"   Elemento en índice 0: {lista.ElementAt(0)}");
        Console.WriteLine($"   Elemento en índice 2: {lista.ElementAt(2)}");

        // 3. Insert - Insertar en posiciones específicas
        Console.WriteLine("\n3. Insertando elementos en posiciones específicas:");
        lista.Insert(0, 5);  // Insertar al principio
        Console.WriteLine($"   Insertado 5 al inicio");
        lista.Insert(3, 25); // Insertar en medio
        Console.WriteLine($"   Insertado 25 en índice 3");
        lista.Insert(lista.Count, 50); // Insertar al final
        Console.WriteLine($"   Insertado 50 al final");
        MostrarLista(lista);

        // 4. Set - Modificar elementos
        Console.WriteLine("\n4. Modificando elementos (Set):");
        lista.Set(1, 100);
        Console.WriteLine($"   Cambiado elemento en índice 1 a 100");
        MostrarLista(lista);

        // 5. Contains - Buscar elementos
        Console.WriteLine("\n5. Buscando elementos (Contains):");
        Console.WriteLine($"   ¿Contiene 25? {lista.Contains(25)}");
        Console.WriteLine($"   ¿Contiene 99? {lista.Contains(99)}");

        // 6. Remove - Eliminar por valor
        Console.WriteLine("\n6. Eliminando elementos por valor (Remove):");
        bool removed = lista.Remove(25);
        Console.WriteLine($"   Remove(25): {removed}");
        MostrarLista(lista);

        // 7. RemoveAt - Eliminar por índice
        Console.WriteLine("\n7. Eliminando elementos por índice (RemoveAt):");
        lista.RemoveAt(0);
        Console.WriteLine($"   Eliminado elemento en índice 0");
        MostrarLista(lista);

        // 8. Iteración con foreach (IEnumerable)
        Console.WriteLine("\n8. Iterando con foreach (IEnumerable<T>):");
        Console.Write("   Elementos: ");
        foreach (var num in lista)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();

        // 9. Trabajar con strings
        Console.WriteLine("\n9. LinkedList<string> con nombres:");
        var nombres = new LL.LinkedList<string>();
        nombres.Add("Ana");
        nombres.Add("Carlos");
        nombres.Add("Elena");
        nombres.Add("David");
        MostrarLista(nombres);
        
        nombres.Insert(2, "Beatriz");
        Console.WriteLine("   Insertando 'Beatriz' en índice 2:");
        MostrarLista(nombres);

        // 10. Clear - Limpiar la lista
        Console.WriteLine("\n10. Limpiando la lista original (Clear):");
        lista.Clear();
        Console.WriteLine($"   Count después de Clear: {lista.Count}");
        MostrarLista(lista);

        Console.WriteLine("\n=== Fin de la demostración ===");
    }

    static void MostrarLista<T>(LL.LinkedList<T> lista)
    {
        Console.Write("   Lista: [");
        for (int i = 0; i < lista.Count; i++)
        {
            Console.Write(lista.ElementAt(i));
            if (i < lista.Count - 1) Console.Write(", ");
        }
        Console.WriteLine($"] (Count: {lista.Count})");
    }
}
