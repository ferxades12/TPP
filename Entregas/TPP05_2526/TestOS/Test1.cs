namespace OrdenSuperior;

using OrdenSuperior;

[TestClass]
public sealed class HOFTest {
    
    // ========== PRUEBAS PARA MAP ==========
    
    [TestMethod]
    public void Map_SameOriginDestinationType_Works() {
        int[] list = [1, 2, 3];
        var result = Program.Map(list, x => x * 2);
        CollectionAssert.AreEqual(new[] { 2, 4, 6 }, result.ToArray());
    }

    [TestMethod]
    public void Map_DifferentOriginDestinationType_Works() {
        string[] list = ["a", "b", "ab", "Aba", "akaaAa"];
        var result = Program.Map(list, x => {
            int count = 0;
            for (int i = 0; i < x.Length; i++) {
                if (x[i] == 'a' || x[i] == 'A') count++;
            }
            return count;
        });
        //Imprimer el resutlado
        CollectionAssert.AreEqual(new[] { 1, 0, 1, 2, 5 }, result.ToArray());
    }

    [TestMethod]
    public void Filter_AllElementsSatisfyCondition_Works() {
        int[] list = new[] { 2, 4, 6 };
        var result = Program.Filter(list, x => x % 2 == 0);
        CollectionAssert.AreEqual(new[] { 2, 4, 6 }, result.ToArray());
    }

    [TestMethod]
    public void Filter_NoElementsSatisfyCondition_Works() {
        int[] list = new[] { 1, 3, 5 };
        var result = Program.Filter(list, x => x % 2 == 0);
        CollectionAssert.AreEqual(Array.Empty<int>(), result.ToArray());
    }

    [TestMethod]
    public void Reduce_SameTypeCollectionDestination_Works() {
        int[] list = [1, 2, 3, 4, 5, 6];
        var result = Program.Reduce(list, (x, y) => x + y, 0);
        Assert.AreEqual(21, result);
    }

    [TestMethod]
    public void Reduce_SameTypeCollectionDestinationWithSeed_Works() {
        int[] list = [4, 1, 3, 5, 2];
        var result = Program.Reduce(list, (x, y) => (x - y < 0)? x : y, int.MaxValue);
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Reduce_DifferentTypeCollectionDestination_Works() {
        string[] list = ["a", "ab", "abc", "abcd"];
        var result = Program.Reduce(list, (x, y) => x + y.Length, 0);
        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void Reduce_DifferentTypeCollectionDestinationWithSeed_Works() {
        string input = "helloo";
        var seed = new Dictionary<char, int>();

        var result = Program.Reduce(
            input,
            (dict, letter) => {
                if ("aeiou".Contains(letter)) {
                    if (dict.TryGetValue(letter, out int value)) {
                        dict[letter] = ++value;
                    } else {
                        dict[letter] = 1;
                    }
                }
                return dict;
            },
            seed
        );


        Assert.AreEqual(1, result['e']);
        Assert.AreEqual(2, result['o']);
        Assert.IsFalse(result.ContainsKey('h'));
    }

    [TestMethod]
    public void Zip_WithSameLengthAndType_Works() {
        int[] list1 = [1, 2, 3];
        int[] list2 = [4, 5, 6];
        var result = Program.Zip(list1, list2, (x, y) => x + y);
        CollectionAssert.AreEqual(new[] { 5, 7, 9 }, result.ToArray());
    }

    [TestMethod]
    public void Zip_WithDifferentLengthAndType_Works() {
        string[] list1 = ["a", "b", "c"];
        int[] list2 = [1, 2];
        var result = Program.Zip(list1, list2, (x, y) => x + y);
        CollectionAssert.AreEqual(new[] { "a1", "b2" }, result.ToArray());
    }
}