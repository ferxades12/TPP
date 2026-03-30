namespace TestSorted;

[TestClass]
public sealed class Test1
{

    #region Pruebas del método Add y ordenamiento

    [TestMethod]
    public void Add_ConEnteros_DeberiaOrdenarCorrectamente()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act
        sortedList.Add(5);
        sortedList.Add(2);
        sortedList.Add(8);
        sortedList.Add(1);
        sortedList.Add(9);

        // Assert
        Assert.AreEqual(1, sortedList.ElementAt(0));
        Assert.AreEqual(2, sortedList.ElementAt(1));
        Assert.AreEqual(5, sortedList.ElementAt(2));
        Assert.AreEqual(8, sortedList.ElementAt(3));
        Assert.AreEqual(9, sortedList.ElementAt(4));
    }

    [TestMethod]
    public void Add_ConStrings_DeberiaOrdenarAlfabeticamente()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act
        sortedList.Add("manzana");
        sortedList.Add("banana");
        sortedList.Add("uva");
        sortedList.Add("cereza");

        // Assert
        Assert.AreEqual("banana", sortedList.ElementAt(0));
        Assert.AreEqual("cereza", sortedList.ElementAt(1));
        Assert.AreEqual("manzana", sortedList.ElementAt(2));
        Assert.AreEqual("uva", sortedList.ElementAt(3));
    }

    [TestMethod]
    public void Add_ConDoubles_DeberiaOrdenarCorrectamente()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act
        sortedList.Add(3.14);
        sortedList.Add(2.71);
        sortedList.Add(1.41);
        sortedList.Add(4.20);

        // Assert
        Assert.AreEqual(1.41, sortedList.ElementAt(0));
        Assert.AreEqual(2.71, sortedList.ElementAt(1));
        Assert.AreEqual(3.14, sortedList.ElementAt(2));
        Assert.AreEqual(4.20, sortedList.ElementAt(3));
    }

    [TestMethod]
    public void Add_ElementosIguales_DeberiaPermitirDuplicados()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act
        sortedList.Add(5);
        sortedList.Add(3);
        sortedList.Add(5);
        sortedList.Add(3);

        // Assert
        Assert.AreEqual(4, sortedList.Count);
        Assert.AreEqual(3, sortedList.ElementAt(0));
        Assert.AreEqual(3, sortedList.ElementAt(1));
        Assert.AreEqual(5, sortedList.ElementAt(2));
        Assert.AreEqual(5, sortedList.ElementAt(3));
    }

    [TestMethod]
    public void Add_EnListaVacia_DeberiaAgregarElemento()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act
        sortedList.Add(10);

        // Assert
        Assert.AreEqual(1, sortedList.Count);
        Assert.AreEqual(10, sortedList.ElementAt(0));
    }

    [TestMethod]
    public void Add_ElementoMenorAlPrimero_DeberiaInsertarAlInicio()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);

        // Act
        sortedList.Add(1);

        // Assert
        Assert.AreEqual(1, sortedList.ElementAt(0));
        Assert.AreEqual(5, sortedList.ElementAt(1));
        Assert.AreEqual(10, sortedList.ElementAt(2));
    }

    [TestMethod]
    public void Add_ElementoMayorAlUltimo_DeberiaInsertarAlFinal()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);

        // Act
        sortedList.Add(20);

        // Assert
        Assert.AreEqual(5, sortedList.ElementAt(0));
        Assert.AreEqual(10, sortedList.ElementAt(1));
        Assert.AreEqual(20, sortedList.ElementAt(2));
    }

    #endregion

    #region Pruebas de Count

    [TestMethod]
    public void Count_ListaVacia_DeberiaSerCero()
    {
        // Arrange & Act
        var sortedList = new SortedList.SortedList();

        // Assert
        Assert.AreEqual(0, sortedList.Count);
    }

    [TestMethod]
    public void Count_DespuesDeAgregar_DeberiaActualizarse()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act & Assert
        sortedList.Add(1);
        Assert.AreEqual(1, sortedList.Count);

        sortedList.Add(2);
        Assert.AreEqual(2, sortedList.Count);

        sortedList.Add(3);
        Assert.AreEqual(3, sortedList.Count);
    }

    #endregion

    #region Pruebas de ElementAt

    [TestMethod]
    public void ElementAt_IndiceValido_DeberiaRetornarElemento()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(10);
        sortedList.Add(20);
        sortedList.Add(30);

        // Act & Assert
        Assert.AreEqual(10, sortedList.ElementAt(0));
        Assert.AreEqual(20, sortedList.ElementAt(1));
        Assert.AreEqual(30, sortedList.ElementAt(2));
    }

    [TestMethod]
    public void ElementAt_IndiceNegativo_DeberiaLanzarExcepcion()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(10);

        // Act & Assert
        try
        {
            sortedList.ElementAt(-1);
            Assert.Fail("Se esperaba IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Excepción esperada
        }
    }

    [TestMethod]
    public void ElementAt_IndiceFueraDeRango_DeberiaLanzarExcepcion()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(10);

        // Act & Assert
        try
        {
            sortedList.ElementAt(5);
            Assert.Fail("Se esperaba IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Excepción esperada
        }
    }

    [TestMethod]
    public void ElementAt_ListaVacia_DeberiaLanzarExcepcion()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act & Assert
        try
        {
            sortedList.ElementAt(0);
            Assert.Fail("Se esperaba IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Excepción esperada
        }
    }

    #endregion

    #region Pruebas de Contains

    [TestMethod]
    public void Contains_ElementoExiste_DeberiaRetornarTrue()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(15);

        // Act & Assert
        Assert.IsTrue(sortedList.Contains(5));
        Assert.IsTrue(sortedList.Contains(10));
        Assert.IsTrue(sortedList.Contains(15));
    }

    [TestMethod]
    public void Contains_ElementoNoExiste_DeberiaRetornarFalse()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);

        // Act & Assert
        Assert.IsFalse(sortedList.Contains(3));
        Assert.IsFalse(sortedList.Contains(20));
    }

    [TestMethod]
    public void Contains_ListaVacia_DeberiaRetornarFalse()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act & Assert
        Assert.IsFalse(sortedList.Contains(10));
    }

    [TestMethod]
    public void Contains_ConStrings_DeberiaFuncionar()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add("hola");
        sortedList.Add("mundo");

        // Act & Assert
        Assert.IsTrue(sortedList.Contains("hola"));
        Assert.IsFalse(sortedList.Contains("adios"));
    }

    [TestMethod]
    public void Contains_ValorNull_DeberiaRetornarFalse()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);

        // Act & Assert
        #pragma warning disable CS8625
        Assert.IsFalse(sortedList.Contains(null));
        #pragma warning restore CS8625
    }

    #endregion

    #region Pruebas de Remove

    [TestMethod]
    public void Remove_ElementoExistente_DeberiaEliminarYRetornarTrue()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(15);

        // Act
        bool result = sortedList.Remove(10);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(2, sortedList.Count);
        Assert.IsFalse(sortedList.Contains(10));
        Assert.AreEqual(5, sortedList.ElementAt(0));
        Assert.AreEqual(15, sortedList.ElementAt(1));
    }

    [TestMethod]
    public void Remove_ElementoNoExistente_DeberiaRetornarFalse()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);

        // Act
        bool result = sortedList.Remove(20);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(2, sortedList.Count);
    }

    [TestMethod]
    public void Remove_PrimerElemento_DeberiaEliminar()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(15);

        // Act
        bool result = sortedList.Remove(5);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(2, sortedList.Count);
        Assert.AreEqual(10, sortedList.ElementAt(0));
    }

    [TestMethod]
    public void Remove_UltimoElemento_DeberiaEliminar()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(15);

        // Act
        bool result = sortedList.Remove(15);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(2, sortedList.Count);
        Assert.AreEqual(5, sortedList.ElementAt(0));
        Assert.AreEqual(10, sortedList.ElementAt(1));
    }

    [TestMethod]
    public void Remove_ListaVacia_DeberiaRetornarFalse()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act
        bool result = sortedList.Remove(10);

        // Assert
        Assert.IsFalse(result);
        Assert.AreEqual(0, sortedList.Count);
    }

    [TestMethod]
    public void Remove_ElementoDuplicado_DeberiaSoloEliminarUno()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(5);
        sortedList.Add(10);

        // Act
        bool result = sortedList.Remove(5);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(2, sortedList.Count);
        Assert.IsTrue(sortedList.Contains(5)); // Todavía existe uno
    }

    #endregion

    #region Pruebas de RemoveAt

    [TestMethod]
    public void RemoveAt_IndiceValido_DeberiaEliminar()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(15);

        // Act
        sortedList.RemoveAt(1);

        // Assert
        Assert.AreEqual(2, sortedList.Count);
        Assert.AreEqual(5, sortedList.ElementAt(0));
        Assert.AreEqual(15, sortedList.ElementAt(1));
    }

    [TestMethod]
    public void RemoveAt_PrimerElemento_DeberiaEliminar()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(15);

        // Act
        sortedList.RemoveAt(0);

        // Assert
        Assert.AreEqual(2, sortedList.Count);
        Assert.AreEqual(10, sortedList.ElementAt(0));
        Assert.AreEqual(15, sortedList.ElementAt(1));
    }

    [TestMethod]
    public void RemoveAt_IndiceNegativo_DeberiaLanzarExcepcion()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(10);

        // Act & Assert
        try
        {
            sortedList.RemoveAt(-1);
            Assert.Fail("Se esperaba IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Excepción esperada
        }
    }

    [TestMethod]
    public void RemoveAt_IndiceFueraDeRango_DeberiaLanzarExcepcion()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(10);

        // Act & Assert
        try
        {
            sortedList.RemoveAt(5);
            Assert.Fail("Se esperaba IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Excepción esperada
        }
    }

    [TestMethod]
    public void RemoveAt_ListaVacia_DeberiaLanzarExcepcion()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act & Assert
        try
        {
            sortedList.RemoveAt(0);
            Assert.Fail("Se esperaba IndexOutOfRangeException");
        }
        catch (IndexOutOfRangeException)
        {
            // Excepción esperada
        }
    }

    #endregion

    #region Pruebas de Clear

    [TestMethod]
    public void Clear_ListaConElementos_DeberiaVaciar()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Add(15);

        // Act
        sortedList.Clear();

        // Assert
        Assert.AreEqual(0, sortedList.Count);
    }

    [TestMethod]
    public void Clear_ListaVacia_NoDeberiaLanzarExcepcion()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act
        sortedList.Clear();

        // Assert
        Assert.AreEqual(0, sortedList.Count);
    }

    [TestMethod]
    public void Clear_DespuesDeVaciar_DeberiaPoderAgregarNuevamente()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        sortedList.Add(5);
        sortedList.Add(10);
        sortedList.Clear();

        // Act
        sortedList.Add(20);
        sortedList.Add(15);

        // Assert
        Assert.AreEqual(2, sortedList.Count);
        Assert.AreEqual(15, sortedList.ElementAt(0));
        Assert.AreEqual(20, sortedList.ElementAt(1));
    }

    #endregion

    #region Pruebas de integración

    [TestMethod]
    public void OperacionesMultiples_DeberiaFuncionarCorrectamente()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();

        // Act & Assert - Agregar elementos
        sortedList.Add(30);
        sortedList.Add(10);
        sortedList.Add(20);
        Assert.AreEqual(3, sortedList.Count);
        Assert.AreEqual(10, sortedList.ElementAt(0));

        // Eliminar elemento medio
        sortedList.Remove(20);
        Assert.AreEqual(2, sortedList.Count);

        // Agregar más elementos
        sortedList.Add(5);
        sortedList.Add(25);
        Assert.AreEqual(4, sortedList.Count);
        Assert.AreEqual(5, sortedList.ElementAt(0));
        Assert.AreEqual(10, sortedList.ElementAt(1));
        Assert.AreEqual(25, sortedList.ElementAt(2));
        Assert.AreEqual(30, sortedList.ElementAt(3));

        // Eliminar por índice
        sortedList.RemoveAt(0);
        Assert.AreEqual(10, sortedList.ElementAt(0));

        // Verificar contains
        Assert.IsTrue(sortedList.Contains(10));
        Assert.IsFalse(sortedList.Contains(5));

        // Limpiar
        sortedList.Clear();
        Assert.AreEqual(0, sortedList.Count);
    }

    [TestMethod]
    public void OrdenamientoGrande_ConMuchosElementos_DeberiaOrdenarCorrectamente()
    {
        // Arrange
        var sortedList = new SortedList.SortedList();
        int[] valores = { 50, 30, 70, 20, 60, 10, 90, 40, 80, 25, 15, 35, 55, 75, 95 };

        // Act
        foreach (int valor in valores)
        {
            sortedList.Add(valor);
        }

        // Assert
        Assert.AreEqual(valores.Length, sortedList.Count);
        
        // Verificar que estén ordenados
        for (int i = 0; i < sortedList.Count - 1; i++)
        {
            int actual = (int)sortedList.ElementAt(i);
            int siguiente = (int)sortedList.ElementAt(i + 1);
            Assert.IsTrue(actual <= siguiente, $"Elemento en {i} ({actual}) debería ser <= que elemento en {i + 1} ({siguiente})");
        }
    }

    #endregion
}
