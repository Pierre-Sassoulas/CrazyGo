using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrazyGo.Core.Tests
{
    [TestClass]
    public class GobanTests
    {
        [TestMethod]
        public void GetHeight()
        {
            var goban = new RegularGoban(7, 9);
            Assert.AreEqual(7, goban.GetHeight());
            Assert.AreEqual(9, goban.GetWidth());
        }
    }
}
