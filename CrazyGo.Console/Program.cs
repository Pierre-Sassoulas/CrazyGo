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

        private static readonly Dictionary<CrazyGo.Core.Color, System.ConsoleColor> mapColor
            = new Dictionary<Color, ConsoleColor>
            {
                { Color.Black, ConsoleColor.DarkBlue },
                { Color.Blue, ConsoleColor.Blue },
                { Color.Green, ConsoleColor.Green },
                { Color.Red, ConsoleColor.Red },
                { Color.White, ConsoleColor.White },
                { Color.Yellow, ConsoleColor.Yellow }
            };

        private static void Main(string[] args)
        {
            Goban goban = new StandardGoban(19, 19);
            Player player1 = new HumanPlayer() { Name = "Human", Color = Color.Black };
            Player player2 = new ComputerPlayer() { Name = "Computer", Color = Color.White };
            Game game = new Game(goban, new Player[] { player1, player2 });

            drawGoban(goban);
            bool stop = false;
            int counter = 0;
            while (!stop)
            {
                nextTurn(game);
                System.Threading.Thread.Sleep(1000);
                stop = counter++ > 10;
            }
            System.Console.CursorSize = 100;
            writeAt(0, goban.GetHeight() + 3, "C'est crazy fini !", true);
        }

        private static void nextTurn(Game game)
        {
            ConsoleColor defaultBg = System.Console.BackgroundColor;
            ConsoleColor defaultFg = System.Console.ForegroundColor;

            Player currentPlayer = game.CurrentPlayer;            
            System.Console.BackgroundColor = ConsoleColor.DarkCyan;
            System.Console.ForegroundColor = mapColor[currentPlayer.Color];
            writeAt(game.GameContext.Goban.GetWidth() + 4, 2, " " + currentPlayer.ToString() + " ");
            game.NextTurn(new PassHand(game.CurrentPlayer));

            System.Console.BackgroundColor = defaultBg;
            System.Console.ForegroundColor = defaultFg;
        }

        private static void writeAt(int left, int top, string text, bool endline = false)
        {
            System.Console.SetCursorPosition(left, top);
            if (endline)
                System.Console.WriteLine(text);
            else
                System.Console.Write(text);
        }


        private static void drawGoban(Goban goban)
        {
            ConsoleColor defaultColor = System.Console.BackgroundColor;
            System.Console.BackgroundColor = ConsoleColor.Gray;
            int height = goban.GetHeight();
            int width = goban.GetWidth();
            for (int h = 1; h <= height; h++)
            {
                writeAt(0, h, " ");
                writeAt(width + 1, h, " ");
            }
            for (int w = 1; w <= width; w++)
            {
                writeAt(w, 0, " ");
                writeAt(w, height + 1, " ");
            }

            System.Console.BackgroundColor = defaultColor;
            writeAt(4, 4, "*");
            writeAt(4, 16, "*");
            writeAt(16, 4, "*");
            writeAt(16, 16, "*");
            writeAt(10, 10, "*");
        }
    }
}
