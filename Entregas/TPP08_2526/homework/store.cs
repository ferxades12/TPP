using Result;
using static Maybe.FMaybe;
using Maybe;

namespace homework;

public static class StoreMaybe
{
    public static Maybe<decimal> GetPrice(string[] names, decimal[] prices, string product)
    {
        if (names == null || prices == null)
            return None<decimal>();

        if (names.Length != prices.Length)
            return None<decimal>();

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] == product)
                return Some(prices[i]);
        }

        return None<decimal>();
    }

    public static Maybe<decimal> UnitsYouCanBuy(decimal budget, decimal price)
    {
        if (price == 0)
            return None<decimal>();

        return Some(budget / price);
    }
}


public static class Store
{
    public static Result<decimal, string> GetPrice(string[] names, decimal[] prices, string product)
    {
        if (names == null || prices == null)
            return new Failure<decimal, string>("Names and prices cannot be null.");

        if (names.Length != prices.Length)
            return new Failure<decimal, string>("Names and prices must have the same length");

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] == product)
                return new Success<decimal, string>(prices[i]);
        }

        return new Failure<decimal, string>("Product not found.");
    }

    public static Result<decimal, string> UnitsYouCanBuy(decimal budget, decimal price)
    {
        if (price == 0)
            return new Failure<decimal, string>("Cannot divide by 0. Price must be != 0");

        return new Success<decimal, string>(budget / price);
    }
}