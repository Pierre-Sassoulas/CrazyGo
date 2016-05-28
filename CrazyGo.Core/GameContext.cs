using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    /// <summary>
    /// Contains the list of players and the goban.
    /// </summary>
    public class GameContext
    {
        private Player[] _players;
        private Goban _goban;

        /// <summary>
        /// The players involved in the game.
        /// </summary>
        public Player[] Players
        {
            get { return _players; }
        }

        /// <summary>
        /// The game goban.
        /// </summary>
        public Goban Goban
        {
            get { return _goban; }
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="players"></param>
        /// <param name="goban"></param>
        public GameContext(Goban goban, Player[] players)
        {
            _players = players;
            _goban = goban;
        }

    }
}
