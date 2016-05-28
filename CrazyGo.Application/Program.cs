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
            Player player = new HumanPlayer();
            Group group = new Group(new Stone(new Position(3, 5), player));
            group.Add(new Stone(new Position(3, 4), player));
            foreach (var p in group.AdjacentPositions)
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
