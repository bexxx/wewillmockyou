using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class StringAsserts
    {
        [TestMethod]
        public void StringTests()
        {
            StringAssert.Contains("hello", "e", "Does not contain");
            StringAssert.Matches("hello", new Regex("h.+lo"), "Does not match");
            StringAssert.StartsWith("hello", "h", "Does not start with");
        }
    }
}
