using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyGo.Core;

namespace CrazyGo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.AddPosition(new Position(1, 2));
            board.AddPosition(new Position(3, 4));
        }
    }
}
