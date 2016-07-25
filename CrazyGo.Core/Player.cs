using System;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a player.
    /// </summary>
    public abstract class Player : IEquatable<Player>
    {
        private Color _color;
        private string _name;

        /// <summary>
        /// Player color.
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public override string ToString()
        {
            return _name + " (" + _color + ")";
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        public PlaceStone PlaceStone(Position position)
        {
            Stone stone = new Stone(position, this);
            return new PlaceStone(stone);
        }

        public PlaceStone PlaceStone(int row, int column)
        {
            return PlaceStone(new Position(row, column));
        }

        /// <summary>
        /// Player name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Equals(Player other)
        {
            return this == other;
        }

        public static bool operator ==(Player p1, Player p2)
        {
            return p1._name == p2._name && p1._color == p2._color;
        }

        public static bool operator !=(Player p1, Player p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            return obj is Player && this == (Player)obj;
        }

        /// <summary>
        /// Plays for a specific turn.
        /// </summary>
        /// <param name="turn"></param>
        /// <returns></returns>
        public abstract Action Play(Turn turn);
    }
}
