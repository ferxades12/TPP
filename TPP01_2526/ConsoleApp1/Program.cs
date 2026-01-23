namespace ConsoleApp1;
using ClassLibrary1;
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
    }
}