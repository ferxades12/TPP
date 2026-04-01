namespace Memoization;

public class MemoizedCalculator<T> where T : System.Numerics.INumber<T>
{
    Dictionary<(Func<T, T, T>, T, T), T> cache = new Dictionary<(Func<T, T, T>, T, T), T>();
    public T? Result {get; private set;}
    
    private void MemoizedOperation(Func<T, T, T> func, T a, T b){
        var key = (func, a, b);
        if(cache.ContainsKey(key)) Result = cache[key];

        T res = func(a, b);
        cache[key] = res;

        Result = res;
    }

    public void Add(T a, T b){
        MemoizedOperation((x, y) => x + y, a, b);
    }

    public void Subtract(T a, T b){
        MemoizedOperation((x, y) => x - y, a, b);
    }

    public void Multiply(T a, T b){
        MemoizedOperation((x, y) => x * y, a, b);
    }

    public void Divide(T a, T b){
        MemoizedOperation((x, y) => x / y, a, b);
    }

    public void Clear(){
        cache.Clear();
    }
}
