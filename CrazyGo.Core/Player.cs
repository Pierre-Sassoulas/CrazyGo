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

        public Player()
        {
            _name = "";
            _color = Color.Black;
        }

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
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return _name == other._name && _color == other._color;
        }

        public override bool Equals(object obj)
        {
            var p = obj as Player;
            if (ReferenceEquals(p, null))
            {
                return false;
            }
            return Equals(p);
        }

        /// <summary>
        /// Plays for a specific turn.
        /// </summary>
        /// <param name="turn"></param>
        /// <returns></returns>
        public abstract Action Play(Turn turn);
    }
}
