using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a computer player.
    /// </summary>
    public class ComputerPlayer : Player
    {
        /// <summary>
        /// Plays for a specific turn.
        /// </summary>
        /// <param name="turn"></param>
        /// <returns></returns>
        public override Action Play(Turn turn)
        {
            IEnumerable<Position> freePositions = turn.FreePositions;
            if (freePositions.Any())
            {
                var randomPosition = freePositions.RandomElement();
                return new PlaceStone(new Stone(randomPosition, this));
            }
            else
            {
                return new PassHand(this);
            }
        }
    }
}
