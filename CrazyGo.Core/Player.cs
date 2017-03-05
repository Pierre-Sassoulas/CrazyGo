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
        /// Default constructor.
        /// </summary>
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

        /// <summary>
        /// Overrides the base method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _name + " (" + _color + ")";
        }

        /// <summary>
        /// Overrides the base method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        /// <summary>
        /// Creates a new <see cref="CrazyGo.Core.Stone"/>, and wraps it in a <see cref="CrazyGo.Core.PlaceStone"/>.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public PlaceStone PlaceStone(Position position)
        {
            Stone stone = new Stone(position, this);
            return new PlaceStone(stone);
        }

        /// <summary>
        /// Creates a new <see cref="CrazyGo.Core.Stone"/>, and wraps it in a <see cref="CrazyGo.Core.PlaceStone"/>.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns true if both objects have same <see cref="Name"/> and same <see cref="Color"/>.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Player other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return _name == other._name && _color == other._color;
        }

        /// <summary>
        /// Overrides the base method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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
