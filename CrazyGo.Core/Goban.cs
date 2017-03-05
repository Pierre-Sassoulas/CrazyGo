using System.Collections.Generic;
using System.Linq;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents the goban (game board).
    /// </summary>
    public class Goban
    {
        /// <summary>
        /// All positions of the goban.
        /// </summary>
        protected HashSet<Position> _positions = new HashSet<Position>();

        /// <summary>
        /// The valid positions on the goban.
        /// </summary>
        public IEnumerable<Position> Positions
        {
            get { return _positions.ToArray(); }
        }

        public int GetHeight()
        {
            return _positions.Max(p => p.Row);
        }

        public int GetWidth()
        {
            return _positions.Max(p => p.Column);
        }

        /// <summary>
        /// Add a position on the goban.
        /// </summary>
        /// <param name="position"></param>
        public void Add(Position position)
        {
            _positions.Add(position);
        }

        public override string ToString()
        {
            return "Goban " + GetHeight() + "x" + GetWidth();
        }
    }
}
