using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace UnitTests
{
    [TestClass]
    class FluentAssertions
    {
        [TestMethod]
        public void FluentAsserts()
        {
            var uut = "hello world!";
            uut.Should()
                .HaveLength(12).And
                .NotBeNullOrEmpty().And
                .ContainAll("world");
        }
    }
}
