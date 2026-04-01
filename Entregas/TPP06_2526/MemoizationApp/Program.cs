namespace Memoization;

class Program
{
    static void Main(string[] args)
    {
        var calc = new MemoizedCalculator<int>();
        calc.Add(1, 2);
        Console.WriteLine(calc.Result); 

        calc.Add(1, 2);
        Console.WriteLine(calc.Result); // Cached

        calc.Clear();

        calc.Add(1, 2);
        Console.WriteLine(calc.Result); // Recalculated

        calc.Multiply(3, 4);
        Console.WriteLine(calc.Result);

        calc.Subtract(10, 5);
        Console.WriteLine(calc.Result);

        calc.Divide(20, 4);
        Console.WriteLine(calc.Result);

        calc.Clear();
        Console.WriteLine(calc.Result);
    }
}