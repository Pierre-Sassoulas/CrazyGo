using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyGo.Core.Tests
{
    [TestClass]
    public class StoneTests
    {
        [TestMethod]
        public void Equals()
        {
            var player1 = new HumanPlayer();
            var s1 = new Stone(1, 3, player1);

            var s2 = new Stone(1, 3, player1);
            Assert.IsTrue(s1.Equals(s2));
            Assert.IsTrue(s1 == s2);

            var s3 = s1;
            Assert.IsTrue(s1.Equals(s3));
            Assert.IsTrue(s1 == s3);

            var s4 = new Stone(1, 1, player1);
            Assert.IsFalse(s1.Equals(s4));
            Assert.IsFalse(s1 == s4);

            var player2 = new HumanPlayer();
            var s5 = new Stone(1, 3, player2);
            Assert.IsFalse(s1.Equals(s5));
            Assert.IsFalse(s1 == s5);
        }
    }
}
