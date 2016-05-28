using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a human player.
    /// </summary>
    public class HumanPlayer : Player
    {
        /// <summary>
        /// Plays for a specific turn.
        /// </summary>
        /// <param name="turn"></param>
        /// <returns></returns>
        public override Action Play(Turn turn)
        {
            throw new NotImplementedException();
        }
    }
}
