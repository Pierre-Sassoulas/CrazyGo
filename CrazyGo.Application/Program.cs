using CrazyGo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Player black = new HumanPlayer() { Color = Color.Black, Name = "Black" };
            Player white = new HumanPlayer() { Color = Color.White, Name = "White" };
            Goban goban = new RegularGoban(3, 4);
            GameContext gameContext = new GameContext(goban, new Player[] { black, white });
            Turn turn = new Turn(gameContext);

            turn = turn.NextTurn(black.PlaceStone(1, 3));
            turn = turn.NextTurn(white.PlaceStone(1, 2));
            turn = turn.NextTurn(black.PlaceStone(2, 4));
            turn = turn.NextTurn(white.PlaceStone(2, 1));
            turn = turn.NextTurn(black.PlaceStone(3, 3));
            turn = turn.NextTurn(white.PlaceStone(3, 2));
            turn = turn.NextTurn(black.PlaceStone(2, 2));
            turn = turn.NextTurn(white.PlaceStone(2, 3));
        }

        private static void TestMergeGroup()
        {
            Player player = new HumanPlayer();
            Group group1 = new Group(new Stone(new Position(3, 5), player));
            Group group2 = new Group(new Stone(new Position(4, 5), player));
            Stone stone = new Stone(new Position(3, 4), player);
            group1 += stone;
            group1 += group2;
            foreach (var p in group1.AdjacentPositions)
                Console.WriteLine(p);
        }

        private static void TestAccessBoardPositions()
        {
            Goban board = new Goban();
            board.Add(new Position(1, 2));
            board.Add(new Position(3, 4));

            foreach (var position in board.Positions)
                Console.WriteLine(position);

            foreach (var position in board.Positions)
                Console.WriteLine(position);
        }
    }
}
