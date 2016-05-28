using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents an action done by a player.
    /// </summary>
    public abstract class Action
    {
        /// <summary>
        /// The player who did the action.
        /// </summary>
        protected Player _player;

        /// <summary>
        /// The player who did the action.
        /// </summary>
        public Player Player
        {
            get { return _player; }
        }
    }
}
