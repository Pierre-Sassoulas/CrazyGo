using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CrazyGo.Core.Tests
{
    [TestClass]
    public class TurnTests
    {
        private Turn _turn;
        private Player _black;
        private Player _white;

        [TestInitialize]
        public void Initialize()
        {
            _black = new HumanPlayer() { Color = Color.Black, Name = "Black" };
            _white = new HumanPlayer() { Color = Color.White, Name = "White" };
            Goban goban = new StandardGoban(3, 4);
            GameContext gameContext = new GameContext(goban, new Player[] { _black, _white });
            _turn = new Turn(gameContext);
        }

        [TestMethod]
        public void TestInitialization()
        {
            Assert.AreEqual(12, _turn.GameContext.Goban.Positions.Count());
            Assert.AreEqual(12, _turn.FreePositions.Count());
            Assert.AreEqual(2, _turn.GameContext.Players.Count());
            Assert.AreEqual("Black", _turn.GameContext.Players[0].Name);
            Assert.AreEqual("White", _turn.GameContext.Players[1].Name);
            Assert.AreEqual(Color.Black, _turn.GameContext.Players[0].Color);
            Assert.AreEqual(Color.White, _turn.GameContext.Players[1].Color);
            Assert.IsNull(_turn.Previous);
        }

        [TestMethod]
        public void PlaceFirstStone()
        {
            _turn = _turn.NextTurn(_black.PlaceStone(1, 3));
            Assert.AreEqual(11, _turn.FreePositions.Count());
            Assert.IsFalse(_turn.FreePositions.Contains(1, 3));
        }

        [TestMethod]
        public void CaptureStone()
        {
            var capturedPosition = new Position(1, 1);
            _turn = _turn.NextTurn(_black.PlaceStone(2, 1));
            _turn = _turn.NextTurn(_white.PlaceStone(capturedPosition));
            Assert.AreEqual(10, _turn.FreePositions.Count());
            Assert.IsFalse(_turn.FreePositions.Contains(capturedPosition));
            _turn = _turn.NextTurn(_black.PlaceStone(1, 2));
            Assert.AreEqual(10, _turn.FreePositions.Count());
            Assert.IsTrue(_turn.FreePositions.Contains(capturedPosition));
        }

        [TestMethod]
        public void KoRule()
        {
            // TODO Assert
            _turn = _turn.NextTurn(_black.PlaceStone(1, 3));
            _turn = _turn.NextTurn(_white.PlaceStone(1, 2));
            _turn = _turn.NextTurn(_black.PlaceStone(2, 4));
            _turn = _turn.NextTurn(_white.PlaceStone(2, 1));
            _turn = _turn.NextTurn(_black.PlaceStone(3, 3));
            _turn = _turn.NextTurn(_white.PlaceStone(3, 2));
            _turn = _turn.NextTurn(_black.PlaceStone(2, 2));
            _turn = _turn.NextTurn(_white.PlaceStone(2, 3));
            Assert.IsNotNull(_turn);
            Assert.AreEqual(5, _turn.FreePositions.Count());

            // This move violates Ko rule
            _turn = _turn.NextTurn(_black.PlaceStone(2, 2));
            Assert.IsNull(_turn);
        }
    }
}
