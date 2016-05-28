using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyGo.Core
{
    public static class GameRules
    {
        public static bool IsLegalAction(Action action, Turn turn)
        {
            if (action.Player != turn.CurrentPlayer)
            {
                return false;
            }

            if (action is PassHand)
            {
                return true;
            }
            else if (action is PlaceStone)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new ArgumentException("Action expected to be PlaceStone or PassHand.");
            }
        }

        public static bool IsCapturing(Stone stone, Turn turn)
        {
            foreach(var group in turn.Groups.Where(g => g.Player!=stone.Player))
            {
                var freedoms = turn.GetFreedoms(group);
                if (freedoms.Contains(stone.Position) && freedoms.Count() == 1)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
