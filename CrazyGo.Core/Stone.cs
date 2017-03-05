using System;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a stone.
    /// </summary>
    public class Stone : IEquatable<Stone>
    {
        private Position _position;
        private Player _player;

        /// <summary>
        /// Stone position.
        /// </summary>
        public Position Position
        {
            get { return _position; }
        }

        /// <summary>
        /// Stone owner.
        /// </summary>
        public Player Player
        {
            get { return _player; }
        }

        /// <summary>
        /// Instantiates a new <see cref="Stone"/>.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="player"></param>
        public Stone(Position position, Player player)
        {
            _position = position;
            _player = player;
        }

        /// <summary>
        /// Instantiates a new <see cref="Stone"/>.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="player"></param>
        public Stone(int row, int column, Player player)
        {
            _position = new Position(row, column);
            _player = player;
        }

        /// <summary>
        /// Overrides the base method.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _position + " " + _player;
        }

        /// <summary>
        /// Returns true if both objects have same <see cref="Player"/> and same <see cref="Position"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Equals(Stone s)
        {
            if (ReferenceEquals(s, null))
            {
                return false;
            }
            return ReferenceEquals(_player, s.Player) && _position == s.Position;
        }

        /// <summary>
        /// Overrides the base method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var s = obj as Stone; ;
            if (ReferenceEquals(s, null))
            {
                return false;
            }
            return Equals(s);
        }

        /// <summary>
        /// Returns true if both objects have same <see cref="Player"/> and same <see cref="Position"/>.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator ==(Stone s1, Stone s2)
        {
            if (ReferenceEquals(s1, s2))
            {
                return true;
            }
            if (ReferenceEquals(s1, null) || ReferenceEquals(s2, null))
            {
                return false;
            }
            return s1.Equals(s2);
        }

        /// <summary>
        /// Returns true if objects are different.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static bool operator !=(Stone s1, Stone s2)
        {
            return !(s1 == s2);
        }

        /// <summary>
        /// Overrides the base method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _position.GetHashCode();
        }
    }
}
