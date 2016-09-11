using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CrazyGo.Core.Tests
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void SetEquals()
        {
            var player = new HumanPlayer();
            var stone1 = new Stone(1, 3, player);
            var stone2 = new Stone(1, 3, player);
            Assert.IsTrue(stone1 == stone2);
            Assert.IsTrue(stone1.Equals(stone2));

            var set1 = new HashSet<Stone>();
            set1.Add(stone1);
            var set2 = new HashSet<Stone>();
            set2.Add(stone2);
            Assert.IsTrue(set1.SetEquals(set2));

            set1.Add(stone1);
            set2.Add(stone1);
            Assert.IsTrue(set1.SetEquals(set2));

            var stone3 = new Stone(1, 4, player);
            set1.Add(stone3);
            Assert.IsFalse(set1.SetEquals(set2));
        }

        [TestMethod]
        public void Equals()
        {
            var player = new HumanPlayer();
            var stone1 = new Stone(1, 3, player);
            var stone2 = new Stone(1, 3, player);
            var group1 = new Group(stone1);
            var group2 = new Group(stone2);

            Assert.IsTrue(group1.Equals(group2));
            Assert.IsTrue(group1 == group2);
            
            var stone3 = new Stone(1, 4, player);
            var group3 = new Group(stone3);
            group2 += group3;
            Assert.IsFalse(group1.Equals(group2));
            Assert.IsTrue(group1 != group2);
        }

        [TestMethod]
        public void AdjacentPositions()
        {
            var player = new HumanPlayer();
            var stone = new Stone(1, 3, player);
            var group = new Group(stone);
            var adjacentPositions = group.AdjacentPositions;
            Assert.IsTrue(adjacentPositions.Count() == 4);
            Assert.IsTrue(adjacentPositions.Contains(0, 3));
            Assert.IsTrue(adjacentPositions.Contains(2, 3));
            Assert.IsTrue(adjacentPositions.Contains(1, 2));
            Assert.IsTrue(adjacentPositions.Contains(1, 4));
            Assert.IsFalse(adjacentPositions.Contains(1, 1));
            Assert.IsFalse(adjacentPositions.Contains(1, 0));
            Assert.IsFalse(adjacentPositions.Contains(1, 3));
        }

        [TestMethod]
        public void OperatorPlus()
        {
            var player = new HumanPlayer();
            var group1 = new Group(new Stone(1, 1, player));
            var group2 = new Group(new Stone(1, 2, player));
            group1 += group2;
            Assert.IsTrue(group1.Positions.Count() == 2);
            Assert.IsTrue(group1.Contains(group2.Stones.ElementAt(0)));            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OperatorPlusException()
        {
            var player = new HumanPlayer();
            var group1 = new Group(new Stone(1, 1, player));
            var group2 = new Group(new Stone(1, 3, player));
            group1 += group2;
        }
    }
}
