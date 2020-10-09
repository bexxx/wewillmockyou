using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DataRowTests
    {
        [DataTestMethod]
        [DataRow(23)]
        public void TestWithData1(int value)
        {
        }

        [DataTestMethod]
        [DataRow(23, "foo")]
        [DataRow(42, "foo", "bar")]
        public void TestWithData2(int numbers, params string[] strings)
        {
        }
    }
}
