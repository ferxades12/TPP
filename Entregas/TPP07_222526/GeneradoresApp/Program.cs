namespace Generadores;
using static global::Generadores.Generadores;
public class Program
{
    static void Main(string[] args) {
        List<int> nums = [1, 2, 3, 4, 5];
        List<string> words = ["uno", "dos", "tres", "cuatro", "cinco"];

        Console.WriteLine("=== MappedEnumerable ===");
        foreach (var x in Map(nums, n => n * 2))
            Console.Write($"{x} ");
        Console.WriteLine();

        Console.WriteLine("=== FilteredEnumerable ===");
        foreach (var x in Filter(nums, n => n % 2 == 0))
            Console.Write($"{x} ");
        Console.WriteLine();

        Console.WriteLine("=== ZippedEnumerable ===");
        foreach (var (n, w) in Zip(nums, words, (n, w) => (n, w)))
            Console.Write($"({n},{w}) ");
        Console.WriteLine();

        Console.WriteLine("=== LazyMap ===");
        foreach (var x in Map(nums, n => n * 2))
            Console.Write($"{x} ");
        Console.WriteLine();

        Console.WriteLine("=== LazyFilter ===");
        foreach (var x in Filter(nums, n => n % 2 == 0))
            Console.Write($"{x} ");
        Console.WriteLine();

        Console.WriteLine("=== LazyZip ===");
        foreach (var (n, w) in Zip(nums, words, (n, w) => (n, w)))
            Console.Write($"({n},{w}) ");
        Console.WriteLine();

        Console.WriteLine("=== LazyTake (3) ===");
        foreach (var x in Take(nums, 3))
            Console.Write($"{x} ");
        Console.WriteLine();

        Console.WriteLine("=== LazyTakeWhile (<4) ===");
        foreach (var x in TakeWhile(nums, n => n < 4))
            Console.Write($"{x} ");
        Console.WriteLine();

        Console.WriteLine("=== LazySkip (2) ===");
        foreach (var x in Skip(nums, 2))
            Console.Write($"{x} ");
        Console.WriteLine();

        Console.WriteLine("=== LazySkipWhile (<4) ===");
        foreach (var x in SkipWhile(nums, n => n < 4))
            Console.Write($"{x} ");
        Console.WriteLine();
    }
}