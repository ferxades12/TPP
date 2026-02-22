using OS;

namespace TestOS;

[TestClass]
public sealed class Test1
{
    #region Map Tests

    /// <summary>
    /// Aplica Map con función del mismo tipo (origen y destino)
    /// Ejemplo: x => x*x (cuadrado de un número)
    /// </summary>
    [TestMethod]
    public void Map_MismoTipo_Cuadrado()
    {
        // Arrange
        IEnumerable<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
        
        // Act
        var resultado = Program.Map(numeros, x => x * x);
        
        // Assert
        CollectionAssert.AreEqual(new List<int> { 1, 4, 9, 16, 25 }, resultado.ToList());
    }

    /// <summary>
    /// Aplica Map con función de tipo destino diferente
    /// Ejemplo: "hello" => 2 (contar vocales)
    /// </summary>
    [TestMethod]
    public void Map_TipoDiferente_ContarVocales()
    {
        // Arrange
        IEnumerable<string> palabras = new List<string> { "hello", "world", "aeiou", "bcdfg" };
        
        // Act
        var resultado = Program.Map(palabras, ContarVocales);
        
        // Assert
        CollectionAssert.AreEqual(new List<int> { 2, 1, 5, 0 }, resultado.ToList());
    }

    private int ContarVocales(string palabra)
    {
        char[] vocales = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        return palabra.Count(c => vocales.Contains(c));
    }

    #endregion

    #region Filter Tests

    /// <summary>
    /// Filtra con condición que cumplen TODOS los elementos
    /// </summary>
    [TestMethod]
    public void Filter_TodosCumplen()
    {
        // Arrange
        IEnumerable<int> numeros = new List<int> { 2, 4, 6, 8, 10 };
        
        // Act
        var resultado = Program.Filter(numeros, x => x % 2 == 0);
        
        // Assert
        CollectionAssert.AreEqual(new List<int> { 2, 4, 6, 8, 10 }, resultado.ToList());
    }

    /// <summary>
    /// Filtra con condición que cumplen ALGUNOS elementos
    /// </summary>
    [TestMethod]
    public void Filter_AlgunosCumplen()
    {
        // Arrange
        IEnumerable<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        // Act
        var resultado = Program.Filter(numeros, x => x % 2 == 0);
        
        // Assert
        CollectionAssert.AreEqual(new List<int> { 2, 4, 6, 8, 10 }, resultado.ToList());
    }

    /// <summary>
    /// Filtra con condición que NO cumple NINGÚN elemento
    /// </summary>
    [TestMethod]
    public void Filter_NingunoCumple()
    {
        // Arrange
        IEnumerable<int> numeros = new List<int> { 1, 3, 5, 7, 9 };
        
        // Act
        var resultado = Program.Filter(numeros, x => x % 2 == 0);
        
        // Assert
        Assert.AreEqual(0, resultado.Count());
        CollectionAssert.AreEqual(new List<int>(), resultado.ToList());
    }

    #endregion

    #region Reduce Tests

    /// <summary>
    /// Aplica Reduce generando el mismo tipo que la colección
    /// Ejemplo: sumatorio de la colección
    /// </summary>
    [TestMethod]
    public void Reduce_MismoTipo_Sumatorio()
    {
        // Arrange
        IEnumerable<int> numeros = new List<int> { 1, 2, 3, 4, 5 };
        
        // Act
        int? resultado = Program.Reduce(numeros, (int elemento, int? acumulador) => 
            (acumulador ?? 0) + elemento);
        
        // Assert
        Assert.AreEqual(15, resultado);
    }

    /// <summary>
    /// Aplica Reduce con semilla (valor inicial)
    /// Ejemplo: mínimo de la colección
    /// </summary>
    [TestMethod]
    public void Reduce_MismoTipoConSemilla_Minimo()
    {
        // Arrange
        IEnumerable<int> numeros = new List<int> { 5, 2, 8, 1, 9, 3 };
        
        // Act
        int? resultado = Program.Reduce(numeros, (int elemento, int? acumulador) =>
        {
            if (acumulador == null)
                return elemento;
            return Math.Min(elemento, acumulador.Value);
        });
        
        // Assert
        Assert.AreEqual(1, resultado);
    }

    /// <summary>
    /// Aplica Reduce generando un tipo destino diferente
    /// Ejemplo: sumatorio de las longitudes de cadenas
    /// </summary>
    [TestMethod]
    public void Reduce_TipoDiferente_SumatorioLongitudes()
    {
        // Arrange
        IEnumerable<string> palabras = new List<string> { "hello", "world", "test", "programming" };
        
        // Act
        int? resultado = Program.Reduce(palabras, (string elemento, int? acumulador) =>
            (acumulador ?? 0) + elemento.Length);
        
        // Assert
        Assert.AreEqual(25, resultado); // 5 + 5 + 4 + 11 = 25
    }

    /// <summary>
    /// Aplica Reduce generando tipo destino diferente con semilla
    /// Ejemplo: diccionario con número de ocurrencias de vocales
    /// </summary>
    [TestMethod]
    public void Reduce_TipoDiferenteConSemilla_DiccionarioVocales()
    {
        // Arrange
        IEnumerable<string> palabras = new List<string> { "hello", "world", "aeiou" };
        
        // Act
        Dictionary<char, int>? resultado = Program.Reduce(palabras, (string elemento, Dictionary<char, int>? acumulador) =>
        {
            var dict = acumulador ?? new Dictionary<char, int>();
            
            foreach (char c in elemento.ToLower())
            {
                if ("aeiou".Contains(c))
                {
                    if (dict.ContainsKey(c))
                        dict[c]++;
                    else
                        dict[c] = 1;
                }
            }
            
            return dict;
        });
        
        // Assert
        Assert.IsNotNull(resultado);
        Assert.AreEqual(2, resultado['e']); // "hello" (1) + "aeiou" (1) = 2
        Assert.AreEqual(3, resultado['o']); // "hello" (1) + "world" (1) + "aeiou" (1) = 3
        Assert.AreEqual(1, resultado['a']); // "aeiou" (1) = 1
        Assert.AreEqual(1, resultado['i']); // "aeiou" (1) = 1
        Assert.AreEqual(1, resultado['u']); // "aeiou" (1) = 1
    }

    #endregion

    #region Zip Tests

    /// <summary>
    /// Aplica Zip a dos colecciones del mismo tipo y misma longitud
    /// </summary>
    [TestMethod]
    public void Zip_MismoTipo_MismaLongitud()
    {
        // Arrange
        IEnumerable<int> numeros1 = new List<int> { 1, 2, 3, 4, 5 };
        IEnumerable<int> numeros2 = new List<int> { 10, 20, 30, 40, 50 };
        
        // Act
        var resultado = Program.Zip(numeros1, numeros2, (a, b) => a + b);
        
        // Assert
        CollectionAssert.AreEqual(new List<int> { 11, 22, 33, 44, 55 }, resultado.ToList());
    }

    /// <summary>
    /// Aplica Zip a dos colecciones con diferentes tipos y longitudes
    /// </summary>
    [TestMethod]
    public void Zip_TiposDiferentes_LongitudesDiferentes()
    {
        // Arrange
        IEnumerable<string> palabras = new List<string> { "a", "bb", "ccc", "dddd", "eeeee", "ffffff" };
        IEnumerable<int> numeros = new List<int> { 1, 2, 3 };
        
        // Act - combina string con int para crear tupla (string, longitud + número)
        var resultado = Program.Zip(palabras, numeros, (palabra, numero) => 
            $"{palabra}:{palabra.Length + numero}");
        
        // Assert
        // Solo toma los primeros 3 elementos (la longitud de la secuencia más corta)
        CollectionAssert.AreEqual(new List<string> { "a:2", "bb:4", "ccc:6" }, resultado.ToList());
    }

    #endregion

    #region Combined Operations Tests

    /// <summary>
    /// Combina Zip + Map
    /// Zip dos listas y luego mapea el resultado
    /// </summary>
    [TestMethod]
    public void Combinado_Zip_Map()
    {
        // Arrange
        IEnumerable<int> numeros1 = new List<int> { 1, 2, 3, 4 };
        IEnumerable<int> numeros2 = new List<int> { 5, 6, 7, 8 };
        
        // Act - Primero hace Zip para sumar, luego Map para elevar al cuadrado
        var zipResult = Program.Zip(numeros1, numeros2, (a, b) => a + b);
        var mapResult = Program.Map(zipResult, x => x * x);
        
        // Assert
        // Zip: {6, 8, 10, 12}, Map: {36, 64, 100, 144}
        CollectionAssert.AreEqual(new List<int> { 36, 64, 100, 144 }, mapResult.ToList());
    }

    /// <summary>
    /// Combina Map + Filter + Reduce
    /// Transforma, filtra y reduce una colección
    /// </summary>
    [TestMethod]
    public void Combinado_Map_Filter_Reduce()
    {
        // Arrange
        IEnumerable<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        // Act
        // 1. Map: eleva al cuadrado -> {1, 4, 9, 16, 25, 36, 49, 64, 81, 100}
        var mapResult = Program.Map(numeros, x => x * x);
        
        // 2. Filter: solo pares -> {4, 16, 36, 64, 100}
        var filterResult = Program.Filter(mapResult, x => x % 2 == 0);
        
        // 3. Reduce: suma -> 220
        int? reduceResult = Program.Reduce(filterResult, (int elemento, int? acumulador) =>
            (acumulador ?? 0) + elemento);
        
        // Assert
        Assert.AreEqual(220, reduceResult); // 4 + 16 + 36 + 64 + 100 = 220
    }

    /// <summary>
    /// Combina Filter + Map + Zip
    /// Filtra dos listas, mapea una de ellas y luego las combina con Zip
    /// </summary>
    [TestMethod]
    public void Combinado_Filter_Map_Zip()
    {
        // Arrange
        IEnumerable<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        IEnumerable<string> palabras = new List<string> { "a", "bb", "ccc", "dddd", "eeeee", "ffffff", "ggggggg" };
        
        // Act
        // 1. Filter: solo números mayores que 5 -> {6, 7, 8, 9, 10}
        var filterResult = Program.Filter(numeros, x => x > 5);
        
        // 2. Map: obtener longitudes de palabras -> {1, 2, 3, 4, 5, 6, 7}
        var mapResult = Program.Map(palabras, p => p.Length);
        
        // 3. Zip: multiplicar cada número filtrado por la longitud correspondiente
        var zipResult = Program.Zip(filterResult, mapResult, (num, len) => num * len);
        
        // Assert
        // {6*1, 7*2, 8*3, 9*4, 10*5} = {6, 14, 24, 36, 50}
        CollectionAssert.AreEqual(new List<int> { 6, 14, 24, 36, 50 }, zipResult.ToList());
    }

    #endregion
}
