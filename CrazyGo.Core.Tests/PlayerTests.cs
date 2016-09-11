using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyGo.Core.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Equals()
        {
            Player p1 = null;
            Player p2 = null;
            Assert.IsTrue(p1 == p2);

            p1 = new HumanPlayer() { Name = "1", Color = Color.Black };
            Assert.IsFalse(p1 == p2);
            Assert.IsFalse(p1.Equals(p2));

            p2 = p1;
            Assert.IsTrue(p1 == p2);
            Assert.IsFalse(p1 != p2);
            Assert.IsTrue(p1.Equals(p2));

            p2 = new HumanPlayer() { Name = "1", Color = Color.Black };
            Assert.IsFalse(p1 == p2);
            Assert.IsTrue(p1 != p2);
            Assert.IsTrue(p1.Equals(p2));

            p2 = new HumanPlayer() { Name = "2", Color = Color.Black };
            Assert.IsFalse(p1 == p2);
            Assert.IsTrue(p1 != p2);
            Assert.IsFalse(p1.Equals(p2));

            p2 = new HumanPlayer() { Name = "1", Color = Color.White};
            Assert.IsFalse(p1 == p2);
            Assert.IsTrue(p1 != p2);
            Assert.IsFalse(p1.Equals(p2));

            Assert.IsFalse(p1.Equals(""));
            Assert.IsFalse(p1.Equals(3));
        }
    }
}
