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
        /// Main constructor.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="player"></param>
        public Stone(Position position, Player player)
        {
            _position = position;
            _player = player;
        }

        public Stone(int row, int column, Player player)
        {
            _position = new Position(row, column);
            _player = player;
        }

        public override string ToString()
        {
            return _position + " " + _player;
        }

        public bool Equals(Stone s)
        {
            if (ReferenceEquals(s, null))
            {
                return false;
            }
            return ReferenceEquals(_player, s.Player) && _position == s.Position;
        }

        public override bool Equals(object obj)
        {
            var s = obj as Stone; ;
            if (ReferenceEquals(s, null))
            {
                return false;
            }
            return Equals(s);
        }

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

        public static bool operator !=(Stone s1, Stone s2)
        {
            return !(s1 == s2);
        }

        public override int GetHashCode()
        {
            return _position.GetHashCode();
        }
    }
}
