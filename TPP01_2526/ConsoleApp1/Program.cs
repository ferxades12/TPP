using ClassLibrary1;
using LL;

namespace ConsoleApp1;
class Program
{
    static void Main(string[] args)
    {
        //Cliente c1 = new Cliente("Alice");
        //Console.WriteLine($"Hola, {c1.Nombre}!");
        Cliente c2 = new Cliente{Nombre = "Alicia", Edad = 30};
        Console.WriteLine(c2);

        HotelStay hs1 = new HotelStay
        {
            Id = "1",
            Hotel = "Hotel",
            FechaEntrada = DateTime.Now.AddDays(5),
            FechaSalida = DateTime.Now,
            TarifaPorNoche = 120.0M,
            RegimenComidas = MealPlan.MediaPension
        };

        LinkedList lista = new LinkedList();
        
        lista.Add(42);                                      
        lista.Add("str");                          
        lista.Add(c2);                                      
        
        Console.WriteLine($"Elementos en la lista: {lista.Count}:");
        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"{lista.ElementAt(i)}");
        }
        
        lista.Insert(1, "nuevo");
        Console.WriteLine($"Elementos en la lista: {lista.Count}:");
        Console.WriteLine($"{lista.ElementAt(1)}");
        
        lista.Set(0, 100);
        Console.WriteLine($"{lista.ElementAt(0)}");
    }
}