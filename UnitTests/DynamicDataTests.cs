using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DynamicDataTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        public void ConcatStringsTest(string part1, string part2, string expected)
        {
            var actual = string.Concat(part1, part2);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new[] { "hello", " world!", "hello world!" };
            yield return new[] { "foo", null, "foo" };
        }
    }
}
