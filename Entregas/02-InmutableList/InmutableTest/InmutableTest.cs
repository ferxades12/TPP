using InmutableList;

namespace Entrega2;

[TestClass]
public class InmutableTest
{
    [TestMethod]
    public void Constructor_CreatesEmptyList()
    {
        var list = new InmutableList.InmutableList();
        Assert.AreEqual(0, list.Count);
    }

    [TestMethod]
    public void Add_SingleElement_IncreasesCount()
    {
        var list = new InmutableList.InmutableList();
        var newList = list.Add(5);

        Assert.AreEqual(0, list.Count);
        Assert.AreEqual(1, newList.Count);
    }

    [TestMethod]
    public void Add_MultipleElements_MaintainsOrder()
    {
        var list = new InmutableList.InmutableList();
        var list1 = list.Add(1);
        var list2 = list1.Add(2);
        var list3 = list2.Add(3);

        Assert.AreEqual(3, list3.Count);
        Assert.AreEqual(1, list3.ElementAt(0));
        Assert.AreEqual(2, list3.ElementAt(1));
        Assert.AreEqual(3, list3.ElementAt(2));
    }

    [TestMethod]
    public void Add_DifferentTypes_AllowsMixedTypes()
    {
        var list = new InmutableList.InmutableList();
        var list1 = list.Add(42);
        var list2 = list1.Add("hello");
        var list3 = list2.Add(3.14);
        var list4 = list3.Add(true);

        Assert.AreEqual(4, list4.Count);
        Assert.AreEqual(42, list4.ElementAt(0));
        Assert.AreEqual("hello", list4.ElementAt(1));
        Assert.AreEqual(3.14, list4.ElementAt(2));
        Assert.IsTrue((bool)list4.ElementAt(3));
    }

    [TestMethod]
    public void Add_NullValue_AcceptsNull()
    {
        var list = new InmutableList.InmutableList();
        var newList = list.Add(null);

        Assert.AreEqual(1, newList.Count);
        Assert.IsNull(newList.ElementAt(0));
    }

    [TestMethod]
    public void ElementAt_ValidIndex_ReturnsCorrectElement()
    {
        var list = new InmutableList.InmutableList().Add("first").Add("second").Add("third");

        Assert.AreEqual("first", list.ElementAt(0));
        Assert.AreEqual("second", list.ElementAt(1));
        Assert.AreEqual("third", list.ElementAt(2));
    }

    [TestMethod]
    public void ElementAt_NegativeIndex_ThrowsException()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(-1));
    }

    [TestMethod]
    public void ElementAt_IndexTooLarge_ThrowsException()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(1));
    }

    [TestMethod]
    public void ElementAt_EmptyList_ThrowsException()
    {
        var list = new InmutableList.InmutableList();
        Assert.Throws<IndexOutOfRangeException>(() => list.ElementAt(0));
    }

    [TestMethod]
    public void Set_ValidIndex_ReplacesElement()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.Set(1, 99);

        Assert.AreEqual(2, list.ElementAt(1));
        Assert.AreEqual(99, newList.ElementAt(1));
        Assert.AreEqual(1, newList.ElementAt(0));
        Assert.AreEqual(3, newList.ElementAt(2));
    }

    [TestMethod]
    public void Set_FirstElement_Works()
    {
        var list = new InmutableList.InmutableList().Add("old");
        var newList = list.Set(0, "new");

        Assert.AreEqual("new", newList.ElementAt(0));
    }

    [TestMethod]
    public void Set_LastElement_Works()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.Set(2, 99);

        Assert.AreEqual(99, newList.ElementAt(2));
    }

    [TestMethod]
    public void Set_WithNull_AcceptsNull()
    {
        var list = new InmutableList.InmutableList().Add(42);
        var newList = list.Set(0, null);

        Assert.IsNull(newList.ElementAt(0));
    }

    [TestMethod]
    public void Set_NegativeIndex_ThrowsException()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Set(-1, 99));
    }

    [TestMethod]
    public void Set_IndexTooLarge_ThrowsException()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Set(1, 99));
    }

    [TestMethod]
    public void Insert_AtBeginning_InsertsCorrectly()
    {
        var list = new InmutableList.InmutableList().Add(2).Add(3);
        var newList = list.Insert(0, 1);

        Assert.AreEqual(3, newList.Count);
        Assert.AreEqual(1, newList.ElementAt(0));
        Assert.AreEqual(2, newList.ElementAt(1));
        Assert.AreEqual(3, newList.ElementAt(2));
    }

    [TestMethod]
    public void Insert_InMiddle_InsertsCorrectly()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(3);
        var newList = list.Insert(1, 2);

        Assert.AreEqual(3, newList.Count);
        Assert.AreEqual(1, newList.ElementAt(0));
        Assert.AreEqual(2, newList.ElementAt(1));
        Assert.AreEqual(3, newList.ElementAt(2));
    }

    [TestMethod]
    public void Insert_AtEnd_InsertsCorrectly()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2);
        var newList = list.Insert(2, 3);

        Assert.AreEqual(3, newList.Count);
        Assert.AreEqual(3, newList.ElementAt(2));
    }

    [TestMethod]
    public void Insert_IntoEmptyList_Works()
    {
        var list = new InmutableList.InmutableList();
        var newList = list.Insert(0, "first");

        Assert.AreEqual(1, newList.Count);
        Assert.AreEqual("first", newList.ElementAt(0));
    }

    [TestMethod]
    public void Insert_NullValue_AcceptsNull()
    {
        var list = new InmutableList.InmutableList().Add(1);
        var newList = list.Insert(0, null);

        Assert.IsNull(newList.ElementAt(0));
        Assert.AreEqual(1, newList.ElementAt(1));
    }

    [TestMethod]
    public void Insert_NegativeIndex_ThrowsException()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(-1, 99));
    }

    [TestMethod]
    public void Insert_IndexTooLarge_ThrowsException()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.Insert(5, 99));
    }

    [TestMethod]
    public void Contains_ExistingElement_ReturnsTrue()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);

        Assert.IsTrue(list.Contains(2));
    }

    [TestMethod]
    public void Contains_NonExistingElement_ReturnsFalse()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);

        Assert.IsFalse(list.Contains(99));
    }

    [TestMethod]
    public void Contains_EmptyList_ReturnsFalse()
    {
        var list = new InmutableList.InmutableList();
        Assert.IsFalse(list.Contains(1));
    }

    [TestMethod]
    public void Contains_NullInList_ReturnsTrue()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(null).Add(3);

        Assert.IsTrue(list.Contains(null));
    }

    [TestMethod]
    public void Contains_NullNotInList_ReturnsFalse()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.IsFalse(list.Contains(null));
    }

    [TestMethod]
    public void Remove_ExistingElement_RemovesFirstOccurrence()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.Remove(2);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(2, newList.Count);
        Assert.AreEqual(1, newList.ElementAt(0));
        Assert.AreEqual(3, newList.ElementAt(1));
    }

    [TestMethod]
    public void Remove_NonExistingElement_ReturnsOriginalList()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.Remove(99);

        Assert.AreEqual(3, newList.Count);
        Assert.AreSame(list, newList);
    }

    [TestMethod]
    public void Remove_FirstElement_Works()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.Remove(1);

        Assert.AreEqual(2, newList.Count);
        Assert.AreEqual(2, newList.ElementAt(0));
    }

    [TestMethod]
    public void Remove_LastElement_Works()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.Remove(3);

        Assert.AreEqual(2, newList.Count);
        Assert.AreEqual(2, newList.ElementAt(1));
    }

    [TestMethod]
    public void Remove_DuplicateElements_RemovesOnlyFirst()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(1).Add(3);
        var newList = list.Remove(1);

        Assert.AreEqual(3, newList.Count);
        Assert.AreEqual(2, newList.ElementAt(0));
        Assert.AreEqual(1, newList.ElementAt(1));
        Assert.AreEqual(3, newList.ElementAt(2));
    }

    [TestMethod]
    public void Remove_Null_RemovesNullValue()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(null).Add(3);
        var newList = list.Remove(null);

        Assert.AreEqual(2, newList.Count);
        Assert.AreEqual(1, newList.ElementAt(0));
        Assert.AreEqual(3, newList.ElementAt(1));
    }

    [TestMethod]
    public void Remove_FromEmptyList_ReturnsOriginalList()
    {
        var list = new InmutableList.InmutableList();
        var newList = list.Remove(1);

        Assert.AreSame(list, newList);
    }

    [TestMethod]
    public void RemoveAt_ValidIndex_RemovesElement()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.RemoveAt(1);

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(2, newList.Count);
        Assert.AreEqual(1, newList.ElementAt(0));
        Assert.AreEqual(3, newList.ElementAt(1));
    }

    [TestMethod]
    public void RemoveAt_FirstIndex_Works()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.RemoveAt(0);

        Assert.AreEqual(2, newList.Count);
        Assert.AreEqual(2, newList.ElementAt(0));
    }

    [TestMethod]
    public void RemoveAt_LastIndex_Works()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.RemoveAt(2);

        Assert.AreEqual(2, newList.Count);
        Assert.AreEqual(2, newList.ElementAt(1));
    }

    [TestMethod]
    public void RemoveAt_SingleElement_CreatesEmptyList()
    {
        var list = new InmutableList.InmutableList().Add(42);
        var newList = list.RemoveAt(0);

        Assert.AreEqual(0, newList.Count);
    }

    [TestMethod]
    public void RemoveAt_NegativeIndex_ThrowsException()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(-1));
    }

    [TestMethod]
    public void RemoveAt_IndexTooLarge_ThrowsException()
    {
        var list = new InmutableList.InmutableList().Add(1);
        Assert.Throws<IndexOutOfRangeException>(() => list.RemoveAt(1));
    }

    [TestMethod]
    public void Clear_NonEmptyList_CreatesEmptyList()
    {
        var list = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var newList = list.Clear();

        Assert.AreEqual(3, list.Count);
        Assert.AreEqual(0, newList.Count);
    }

    [TestMethod]
    public void Clear_EmptyList_ReturnsEmptyList()
    {
        var list = new InmutableList.InmutableList();
        var newList = list.Clear();

        Assert.AreEqual(0, newList.Count);
    }

    [TestMethod]
    public void Immutability_OriginalListUnchangedAfterAdd()
    {
        var original = new InmutableList.InmutableList().Add(1).Add(2);
        var modified = original.Add(3);

        Assert.AreEqual(2, original.Count);
        Assert.AreEqual(3, modified.Count);
    }

    [TestMethod]
    public void Immutability_OriginalListUnchangedAfterSet()
    {
        var original = new InmutableList.InmutableList().Add(1).Add(2);
        var modified = original.Set(0, 99);

        Assert.AreEqual(1, original.ElementAt(0));
        Assert.AreEqual(99, modified.ElementAt(0));
    }

    [TestMethod]
    public void Immutability_OriginalListUnchangedAfterRemove()
    {
        var original = new InmutableList.InmutableList().Add(1).Add(2).Add(3);
        var modified = original.Remove(2);

        Assert.AreEqual(3, original.Count);
        Assert.AreEqual(2, modified.Count);
    }

    [TestMethod]
    public void Immutability_ChainedOperations_EachInstanceIndependent()
    {
        var list1 = new InmutableList.InmutableList().Add(1);
        var list2 = list1.Add(2);
        var list3 = list2.Add(3);
        var list4 = list2.Add(99);

        Assert.AreEqual(1, list1.Count);
        Assert.AreEqual(2, list2.Count);
        Assert.AreEqual(3, list3.Count);
        Assert.AreEqual(3, list4.Count);
        Assert.AreEqual(3, list3.ElementAt(2));
        Assert.AreEqual(99, list4.ElementAt(2));
    }
}
