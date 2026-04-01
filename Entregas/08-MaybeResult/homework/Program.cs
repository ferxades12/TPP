namespace homework;

using Result;
using Maybe;

class Program
{
    static void Main(string[] args)
    {
        string[] productNames = { "Laptop", "Mouse", "Keyboard", "Sticker" };
        decimal[] productPrices = { 800m, 25m, 50m, 0m };

        decimal budget = 1000m;

        RunCase(productNames, productPrices, budget, "Laptop");
        RunCase(productNames, productPrices, budget, "Sticker");
        RunCase(productNames, productPrices, budget, "Monitor");

        Console.WriteLine("Usando Maybe:");
        RunCaseMaybe(productNames, productPrices, budget, "Laptop");
        RunCaseMaybe(productNames, productPrices, budget, "Sticker");
        RunCaseMaybe(productNames, productPrices, budget, "Monitor");
    }

    private static void RunCase(string[] names, decimal[] prices, decimal budget, string product)
    {
        Console.WriteLine($"Caso: producto = {product}");
        var priceResult = Store.GetPrice(names, prices, product);
        priceResult.Match(
            price =>
            {
                var unitsResult = Store.UnitsYouCanBuy(budget, price);
                unitsResult.Match(
                    units =>
                    {
                        Console.WriteLine($"  Precio: {price}");
                        Console.WriteLine($"  Unidades que puedes comprar con {budget}: {units}");
                    },
                    error =>
                    {
                        Console.WriteLine($"  Error: {error}");
                    }
                );
            },
            error =>
            {
                Console.WriteLine($"  Error: {error}");
            }
        );

        Console.WriteLine();
    }

    private static void RunCaseMaybe(string[] names, decimal[] prices, decimal budget, string product)
    {
        Console.WriteLine($"Caso: producto = {product}");
        var price = StoreMaybe.GetPrice(names, prices, product);
        price.Match(
            price =>
            {
                var units = StoreMaybe.UnitsYouCanBuy(budget, price);
                units.Match(
                    units =>
                    {
                        Console.WriteLine($"  Precio: {price}");
                        Console.WriteLine($"  Unidades que puedes comprar con {budget}: {units}");
                    },
                    () =>
                    {
                        Console.WriteLine($"  No se pudo calcular las unidades que puedes comprar con {budget} y precio {price}");
                    }
                );
            },
            () =>
            {
                Console.WriteLine($"  No se pudo encontrar el precio del producto {product}");
            }
        );

        Console.WriteLine();
    }
}