namespace CrazyGo.Core
{
    /// <summary>
    /// Represents the action of placing a stone on the goban.
    /// </summary>
    public class PlaceStone : Action
    {
        private Stone _stone;

        /// <summary>
        /// The stone being placed.
        /// </summary>
        public Stone Stone
        {
            get { return _stone; }
        }

        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="stone"></param>
        public PlaceStone(Stone stone)
        {
            _player = stone.Player;
            _stone = stone;
        }
    }
}
