namespace CrazyGo.Core
{
    /// <summary>
    /// Represents the action of passing hand.
    /// </summary>
    public class PassHand : Action
    {
        /// <summary>
        /// Main constructor.
        /// </summary>
        /// <param name="player"></param>
        public PassHand(Player player)
        {
            _player = player;
        }
    }
}
