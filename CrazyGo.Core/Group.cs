using System;
using System.Collections.Generic;
using System.Linq;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a group of stones.
    /// </summary>
    public class Group
    {
        private HashSet<Stone> _stones;
        private Player _player;

        /// <summary>
        /// Stones that belong to this group.
        /// </summary>
        public IEnumerable<Stone> Stones
        {
            get { return _stones.ToArray(); }
        }

        /// <summary>
        /// Group owner.
        /// </summary>
        public Player Player
        {
            get { return _player; }
        }

        /// <summary>
        /// Instantiates a new group from a single stone.
        /// </summary>
        /// <param name="stone">The stone from which the group is instantiated.</param>
        public Group(Stone stone)
        {
            _stones = new HashSet<Stone>();
            _stones.Add(stone);
            _player = stone.Player;
        }

        /// <summary>
        /// Add a stone in the group.
        /// </summary>
        /// <param name="stone"></param>
        /// <exception cref="ArgumentException">Thrown when the stone has not the same ownership (player) as the group's one.</exception>
        /// <exception cref="ArgumentException">Thrown when the stone is not adjacent to this group.</exception>
        public void Add(Stone stone)
        {
            if (stone.Player != _player)
            {
                throw new ArgumentException("stone has not the same ownership (" + stone.Player + ") as the group's one (" + _player + ")");
            }
            if (!AdjacentPositions.Contains(stone.Position))
            {
                throw new ArgumentException("Stone " + stone + " is not adjacent to this group");
            }
            _stones.Add(stone);
        }

        /// <summary>
        /// Positions adjacent to the group. Careful: these positions are NOT necessarily free positions.
        /// This property does NOT take into account neither the goban, nor the other groups on the goban.
        /// Returned positions may be invalid (not in goban), or occupied by other groups.
        /// </summary>
        public IEnumerable<Position> AdjacentPositions
        {
            get
            {
                return Positions.Select(p => new Position(p.Row + 1, p.Column))
                .Union(Positions.Select(p => new Position(p.Row - 1, p.Column)))
                .Union(Positions.Select(p => new Position(p.Row, p.Column + 1)))
                .Union(Positions.Select(p => new Position(p.Row, p.Column - 1)))
                .Where(p => !Positions.Contains(p));
            }
        }


        /// <summary>
        /// Positions involved in the group.
        /// </summary>
        public IEnumerable<Position> Positions
        {
            get { return _stones.Select(s => s.Position); }
        }

        /// <summary>
        /// Returns <code>true</code> if the group contains the position.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool Contains(Position position)
        {
            return Positions.Contains(position);
        }

        /// <summary>
        /// Returns <code>true</code> if the group contains the stone.
        /// </summary>
        /// <param name="stone"></param>
        /// <returns></returns>
        public bool Contains(Stone stone)
        {
            return _stones.Contains(stone);
        }

    }
}
