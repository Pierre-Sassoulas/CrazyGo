using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyGo.Core.Tests
{
    [TestClass]
    public class PositionTests
    {
        [TestMethod]
        public void Equals()
        {
            var p1 = new Position(1, 1);
            var p2 = new Position(1, 1);
            Assert.IsTrue(p1.Equals(p2));
            Assert.IsTrue(p1 == p2);
            var p3 = new Position(1, 2);
            Assert.IsFalse(p1.Equals(p3));
            Assert.IsFalse(p1 == p3);
            var p4 = p1;
        }
    }
}
