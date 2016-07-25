namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a stone.
    /// </summary>
    public class Stone
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

        public override string ToString()
        {
            return _position + " " + _player;
        }

    }
}
