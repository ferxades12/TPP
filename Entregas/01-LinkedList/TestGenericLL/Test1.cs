namespace LinkedList;

[TestClass]
public sealed class Test1
{
    #region Add Tests

    [TestMethod]
    public void Add_SingleElement_CountIsOne()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.AreEqual(1, list.Count);
    }

    [TestMethod]
    public void Add_MultipleElements_CountIsCorrect()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        Assert.AreEqual(3, list.Count);
    }

    [TestMethod]
    public void Add_DifferentTypes_ElementsAreAdded()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add("texto");
        list.Add(3.14);
        list.Add(true);
        Assert.AreEqual(4, list.Count);
    }

    [TestMethod]
    public void Add_NullValue_NullIsAdded()
    {
        var list = new LinkedList();
        list.Add(null);
        Assert.AreEqual(1, list.Count);
        Assert.IsNull(list.ElementAt(0));
    }

    #endregion

    #region ElementAt Tests

    [TestMethod]
    public void ElementAt_FirstElement_ReturnsCorrectValue()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        Assert.AreEqual(10, list.ElementAt(0));
    }

    [TestMethod]
    public void ElementAt_LastElement_ReturnsCorrectValue()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        Assert.AreEqual(30, list.ElementAt(2));
    }

    [TestMethod]
    public void ElementAt_DifferentTypes_ReturnsCorrectValues()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add("texto");
        list.Add(3.14);

        Assert.AreEqual(10, list.ElementAt(0));
        Assert.AreEqual("texto", list.ElementAt(1));
        Assert.AreEqual(3.14, list.ElementAt(2));
    }

    [TestMethod]
    public void ElementAt_NegativeIndex_ThrowsException()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.ElementAt(-1));
    }

    [TestMethod]
    public void ElementAt_IndexOutOfRange_ThrowsException()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.ElementAt(5));
    }

    [TestMethod]
    public void ElementAt_EmptyList_ThrowsException()
    {
        var list = new LinkedList();
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.ElementAt(0));
    }

    #endregion

    #region Set Tests

    [TestMethod]
    public void Set_FirstElement_ValueIsUpdated()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Set(0, 100);
        Assert.AreEqual(100, list.ElementAt(0));
    }

    [TestMethod]
    public void Set_LastElement_ValueIsUpdated()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Set(2, 300);
        Assert.AreEqual(300, list.ElementAt(2));
    }

    [TestMethod]
    public void Set_ToNull_ValueIsSetToNull()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Set(0, null);
        Assert.IsNull(list.ElementAt(0));
    }

    [TestMethod]
    public void Set_NegativeIndex_ThrowsException()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.Set(-1, 100));
    }

    [TestMethod]
    public void Set_IndexOutOfRange_ThrowsException()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.Set(5, 100));
    }

    #endregion

    #region Insert Tests

    [TestMethod]
    public void Insert_AtBeginning_ElementIsInserted()
    {
        var list = new LinkedList();
        list.Add(20);
        list.Add(30);
        list.Insert(0, 10);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(10, list.ElementAt(0));
        Assert.AreEqual(20, list.ElementAt(1));
        Assert.AreEqual(30, list.ElementAt(2));
    }

    [TestMethod]
    public void Insert_InMiddle_ElementIsInserted()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(30);
        list.Insert(1, 20);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(10, list.ElementAt(0));
        Assert.AreEqual(20, list.ElementAt(1));
        Assert.AreEqual(30, list.ElementAt(2));
    }

    [TestMethod]
    public void Insert_AtEnd_ElementIsInserted()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Insert(2, 30);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(30, list.ElementAt(2));
    }

    [TestMethod]
    public void Insert_InEmptyList_ElementIsInserted()
    {
        var list = new LinkedList();
        list.Insert(0, 10);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(10, list.ElementAt(0));
    }

    [TestMethod]
    public void Insert_NegativeIndex_ThrowsException()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(-1, 5));
    }

    [TestMethod]
    public void Insert_IndexOutOfRange_ThrowsException()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.Insert(5, 100));
    }

    #endregion

    #region Contains Tests

    [TestMethod]
    public void Contains_ExistingElement_ReturnsTrue()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.IsTrue(list.Contains(20));
    }

    [TestMethod]
    public void Contains_NonExistingElement_ReturnsFalse()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);

        Assert.IsFalse(list.Contains(100));
    }

    [TestMethod]
    public void Contains_EmptyList_ReturnsFalse()
    {
        var list = new LinkedList();
        Assert.IsFalse(list.Contains(10));
    }

    [TestMethod]
    public void Contains_NullInList_ReturnsTrue()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(null);
        list.Add(20);

        Assert.IsTrue(list.Contains(null));
    }

    [TestMethod]
    public void Contains_SearchNullInListWithoutNull_ReturnsFalse()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);

        Assert.IsFalse(list.Contains(null));
    }

    [TestMethod]
    public void Contains_DifferentTypes_FindsCorrectType()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add("texto");
        list.Add(3.14);

        Assert.IsTrue(list.Contains("texto"));
        Assert.IsFalse(list.Contains("otro"));
    }

    #endregion

    #region Remove Tests

    [TestMethod]
    public void Remove_ExistingElement_RemovesAndReturnsTrue()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Remove(20);

        Assert.IsTrue(result);
        Assert.AreEqual(2, list.Count);
        Assert.IsFalse(list.Contains(20));
    }

    [TestMethod]
    public void Remove_FirstElement_RemovesCorrectly()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Remove(10);

        Assert.IsTrue(result);
        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(20, list.ElementAt(0));
    }

    [TestMethod]
    public void Remove_LastElement_RemovesCorrectly()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        bool result = list.Remove(30);

        Assert.IsTrue(result);
        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void Remove_NonExistingElement_ReturnsFalse()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);

        bool result = list.Remove(100);

        Assert.IsFalse(result);
        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void Remove_FromEmptyList_ReturnsFalse()
    {
        var list = new LinkedList();
        bool result = list.Remove(10);

        Assert.IsFalse(result);
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void Remove_NullValue_RemovesNullAndReturnsTrue()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(null);
        list.Add(20);

        bool result = list.Remove(null);

        Assert.IsTrue(result);
        Assert.AreEqual(2, list.Count);
        Assert.IsFalse(list.Contains(null));
    }

    [TestMethod]
    public void Remove_OnlyElement_ListBecomesEmpty()
    {
        var list = new LinkedList();
        list.Add(10);

        bool result = list.Remove(10);

        Assert.IsTrue(result);
        Assert.AreEqual(0, list.Count);
    }

    #endregion

    #region RemoveAt Tests

    [TestMethod]
    public void RemoveAt_FirstElement_RemovesCorrectly()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.RemoveAt(0);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(20, list.ElementAt(0));
    }

    [TestMethod]
    public void RemoveAt_MiddleElement_RemovesCorrectly()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.RemoveAt(1);

        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(10, list.ElementAt(0));
        Assert.AreEqual(30, list.ElementAt(1));
    }

    [TestMethod]
    public void RemoveAt_LastElement_RemovesCorrectly()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.RemoveAt(2);

        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void RemoveAt_NegativeIndex_ThrowsException()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(-1));
    }

    [TestMethod]
    public void RemoveAt_IndexOutOfRange_ThrowsException()
    {
        var list = new LinkedList();
        list.Add(10);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(5));
    }

    [TestMethod]
    public void RemoveAt_EmptyList_ThrowsException()
    {
        var list = new LinkedList();
        Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveAt(0));
    }

    #endregion

    #region Clear Tests

    [TestMethod]
    public void Clear_ListWithElements_BecomesEmpty()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        list.Clear();

        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void Clear_EmptyList_RemainsEmpty()
    {
        var list = new LinkedList();
        list.Clear();

        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void Clear_AfterClear_CanAddNewElements()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Clear();
        list.Add(20);

        Assert.AreEqual(1, list.Count);
        Assert.AreEqual(20, list.ElementAt(0));
    }

    #endregion

    #region Count Tests

    [TestMethod]
    public void Count_EmptyList_ReturnsZero()
    {
        var list = new LinkedList();
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void Count_AfterAdd_IncrementsCorrectly()
    {
        var list = new LinkedList();
        Assert.AreEqual(0, list.Count);

        list.Add(10);
        Assert.AreEqual(1, list.Count);

        list.Add(20);
        Assert.AreEqual(2, list.Count);
    }

    [TestMethod]
    public void Count_AfterRemove_DecrementsCorrectly()
    {
        var list = new LinkedList();
        list.Add(10);
        list.Add(20);
        Assert.AreEqual(2, list.Count);

        list.Remove(10);
        Assert.AreEqual(1, list.Count);
    }

    #endregion

    #region Integration Tests

    [TestMethod]
    public void Integration_ComplexOperations_WorkCorrectly()
    {
        var list = new LinkedList();

        // Agregar elementos
        list.Add(10);
        list.Add(20);
        list.Add(30);
        Assert.AreEqual(3, list.Count);

        // Insertar en medio
        list.Insert(1, 15);
        Assert.AreEqual(4, list.Count);
        Assert.AreEqual(15, list.ElementAt(1));

        // Modificar valor
        list.Set(2, 25);
        Assert.AreEqual(25, list.ElementAt(2));

        // Verificar contiene
        Assert.IsTrue(list.Contains(25));
        Assert.IsFalse(list.Contains(20));

        // Eliminar por valor
        list.Remove(15);
        Assert.AreEqual(3, list.Count);

        // Eliminar por índice
        list.RemoveAt(0);
        Assert.AreEqual(2, list.Count);
        Assert.AreEqual(25, list.ElementAt(0));
    }

    [TestMethod]
    public void Integration_WithStrings_WorksCorrectly()
    {
        var list = new LinkedList();

        list.Add("Hola");
        list.Add("Mundo");
        list.Add("!");

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual("Mundo", list.ElementAt(1));

        list.Insert(1, "Hermoso");
        Assert.AreEqual("Hermoso", list.ElementAt(1));
        Assert.AreEqual("Mundo", list.ElementAt(2));

        Assert.IsTrue(list.Contains("Hermoso"));
        list.Remove("Hermoso");
        Assert.IsFalse(list.Contains("Hermoso"));
    }

    #endregion
}
