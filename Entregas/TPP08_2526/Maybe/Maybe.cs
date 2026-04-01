namespace Maybe;

public interface Maybe<TData>
{
    // Ejecuta un Action distinto según haya some o none.
    void Match(Action<TData> onSome, Action onNone);

    // Con Func
    TResult Match<TResult>(Func<TData, TResult> onSome, Func<TResult> onNone);

    // En este ejemplo, trataremos AndThen como un map: transforma TData en TMaybe.
    // En ese caso, al devolver un Maybe en lugar de un TMaybe, podríamos encadenar operaciones que también devuelvan Maybe.
    Maybe<TResult> AndThen<TResult>(Func<TData, TResult> f);


    // Devuelve el valor de some o, si es none, un valor por defecto.
    TData OrElse(TData defaultValue);
}

// Gsetión de Some
public record Some<TData>(TData Value) : Maybe<TData>
{
    // Ejecuta la acción de some.
    public void Match(Action<TData> onSome, Action onNone) => onSome(Value);

    // Aplica la función de some y devuelve su resultado.
    public TMaybe Match<TMaybe>(Func<TData, TMaybe> onSome, Func<TMaybe> onNone) => onSome(Value);

    // Traansforma el valor y lo vuelve a envolver en Some.
    public Maybe<TMaybe> AndThen<TMaybe>(Func<TData, TMaybe> f) => new Some<TMaybe>(f(Value));

    // Ignora el valor por defecto y devuelve el valor real.
    public TData OrElse(TData defaultValue) => Value;
}

// Exactamente igual pero adaptado al None.
public record None<TData>() : Maybe<TData>
{
    public void Match(Action<TData> onSome, Action onNone) => onNone();
    public TMaybe Match<TMaybe>(Func<TData, TMaybe> onSome, Func<TMaybe> onNone) => onNone();
    public Maybe<TMaybe> AndThen<TMaybe>(Func<TData, TMaybe> f) => new None<TMaybe>();
    public TData OrElse(TData defaultValue) => defaultValue;
}

public static class FMaybe{
    public static Maybe<T> Some<T> (T arg) => new Some<T>(arg);
    public static Maybe<T> None<T> () => new None<T>();      
}