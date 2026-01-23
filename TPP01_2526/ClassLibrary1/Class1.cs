namespace ClassLibrary1;


public enum Status {VIP, Business, Standard};

public class Cliente
{
    public string Id { get; set; } = "";
    public string _nombre = "";
    public string Nombre
    {
        get { return _nombre; }
        set
        {
            if (value == null)
                throw new ArgumentException("El nombre no puede ser null");
            _nombre = value;
        }
    }
    public string Apellido { get; set; } = "";
    public int _edad = 0;
    public int Edad
    {
        get { return _edad; }
        set
        {
            if (value < 0)
                throw new ArgumentException("La edad no puede ser negativa");
            _edad = value;
        }
    }
    public Status Status { get; set; } = Status.Standard;
    /* public Cliente(string nombre)
    {
        Nombre = nombre;
    } */

    override public string ToString()
    {
        return $"Nombre: {Nombre}, Apellido: {Apellido}, Edad: {Edad}, Status: {Status}";
    }
}

public enum OrderStatus {Borrador, Pagado, Enviado, Entregado, Cancelado};
class Order
{
    public string Identificador { get; set; } = "";
    public string Nombre { get; set; } = "";
    public decimal Cantidad { get; set; } = 0.0M;
    public decimal Precio { get; set; } = 0.0M;
    public decimal GastosEnvio { get; set; } = 0.0M;
    public decimal Subtotal
    {
        get { return Cantidad * Precio; }
    }
    public decimal Total { 
        get { return Subtotal + GastosEnvio; } 
    }
    public OrderStatus Status { get; set; } = OrderStatus.Borrador; 
}

public enum MealPlan {Alojamiento, Desayuno, MediaPension, PensionCompleta};

public class HotelStay
{
    public string Id = "";
    public string Hotel = "";
    public DateTime FechaEntrada;
    public DateTime FechaSalida;
    public decimal TarifaPorNoche = 0.0M;
    public decimal NumeroNoches
    {
        get
        {
            int days = (FechaSalida - FechaEntrada).Days;
            if (days < 0)
                throw new ArgumentException("La fecha de salida no puede ser anterior a la de entrada");
            return days;
        }
    }
    public decimal Total
    {
        get { return NumeroNoches * TarifaPorNoche; }
    }

    public MealPlan RegimenComidas { get; set; } = MealPlan.Alojamiento;
}
