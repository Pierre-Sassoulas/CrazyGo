using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a game of go.
    /// </summary>
    public class Game
    {
        private List<Turn> _turns = new List<Turn>();

        /// <summary>
        /// History of turns.
        /// </summary>
        public IEnumerable<Turn> Turns
        {
            get { return _turns.ToArray(); }
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="goban"></param>
        /// <param name="players"></param>
        public Game(Goban goban, Player[] players)
        {
            GameContext gameContext = new GameContext(goban, players);
        }


    }
}
