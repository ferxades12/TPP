namespace Memoization;

public class MemoizedCalculator<T> where T : System.Numerics.INumber<T>
{
    Dictionary<(Func<T, T, T>, T, T), T> cache = new Dictionary<(Func<T, T, T>, T, T), T>();
    
    private T MemoizedOperation(Func<T, T, T> func, T a, T b){
        var key = (func, a, b);
        if(cache.ContainsKey(key)) return cache[key];

        T res = func(a, b);
        cache[key] = res;

        return res;
    }

    public T Add(T a, T b){
        return MemoizedOperation((x, y) => x + y, a, b);
    }

    public T Subtract(T a, T b){
        return MemoizedOperation((x, y) => x - y, a, b);
    }

    public T Multiply(T a, T b){
        return MemoizedOperation((x, y) => x * y, a, b);
    }

    public T Divide(T a, T b){
        return MemoizedOperation((x, y) => x / y, a, b);
    }

    public void Clear(){
        cache.Clear();
    }
}
