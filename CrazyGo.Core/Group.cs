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

        public Group(Group group)
        {
            _stones = new HashSet<Stone>(group.Stones);
            _player = group.Player;
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
        /// Merge a stone with a group into a NEW group.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="stone"></param>
        /// <returns></returns>
        public static Group operator +(Group group, Stone stone)
        {
            Group result = new Group(group);
            if (stone.Player != group._player)
            {
                throw new ArgumentException("Stone (" + stone.Player + ") and group (" + group._player + ") cannot be merged.");
            }
            if (!group.AdjacentPositions.Contains(stone.Position))
            {
                throw new ArgumentException("Stone and group being merged must be adjacent.");
            }
            result._stones.Add(stone);
            return result;
        }

        public static bool operator ==(Group g1, Group g2)
        {
            return g1._player == g2._player &&
                   g1._stones.SetEquals(g2._stones);
        }

        public static bool operator !=(Group g1, Group g2)
        {
            return !(g1 == g2);
        }

        /// <summary>
        /// Merge two different groups into a NEW group.
        /// </summary>
        /// <param name="group1"></param>
        /// <param name="group2"></param>
        /// <returns></returns>
        public static Group operator +(Group group1, Group group2)
        {
            Group result = new Group(group1);
            if (group1._player != group2._player)
            {
                throw new ArgumentException("Group (" + group1._player + ") and group (" + group2._player + ") cannot be merged.");
            }
            if (!group1.AdjacentPositions.Intersect(group2.AdjacentPositions).Any())
            {
                throw new ArgumentException("Groups being merged must be adjacent.");
            }
            result._stones = new HashSet<Stone>(group1._stones.Union(group2._stones));
            return result;
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
