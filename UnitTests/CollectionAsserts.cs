namespace UnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CollectionAsserts
    {
        [TestMethod]
        public void CollectionTests()
        {
            var actual1 = new[] { 23, 42 }; 
            var actual2 = new[] { 23 };
            var expected1 = new[] { 42, 23 };
            CollectionAssert.AreEquivalent(expected1, actual1, "Not equivalent");
            CollectionAssert.AllItemsAreUnique(expected1, "Not unique");
            CollectionAssert.IsSubsetOf(actual2, expected1, "Is not subset");
            CollectionAssert.Contains(actual1, expected1[0], "Does not contain element");
            CollectionAssert.AllItemsAreInstancesOfType(actual1, typeof(int), "Not all elements are int");
        }
    }
}
