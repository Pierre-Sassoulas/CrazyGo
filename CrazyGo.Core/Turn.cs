using System;
using System.Collections.Generic;
using System.Linq;

namespace CrazyGo.Core
{
    /// <summary>
    /// Represents a single turn within a game.
    /// </summary>
    public class Turn
    {
        private GameContext _gameContext;
        private int _playerTurn;
        private HashSet<Group> _groups;

        /// <summary>
        /// Instantiates a Turn by specifying all properties.
        /// </summary>
        /// <param name="gameContext"></param>
        /// <param name="playerTurn"></param>
        /// <param name="groups"></param>
        public Turn(GameContext gameContext, int playerTurn, IEnumerable<Group> groups)
        {
            _gameContext = gameContext;
            _playerTurn = playerTurn;
            _groups = new HashSet<Group>(groups);
        }

        public Turn InitializeNextTurn()
        {
            Turn nextTurn = new Turn(_gameContext);
            nextTurn._playerTurn = (_playerTurn++) % _gameContext.Players.Length;
            return nextTurn;
        }

        /// <summary>
        /// Instantiates a new Turn with empty collection of groups.
        /// Use this constructor for the first Turn of a <see cref="Game"/>.
        /// </summary>
        /// <param name="gameContext"></param>
        public Turn(GameContext gameContext)
        {
            _gameContext = gameContext;
            _playerTurn = 0;
            _groups = new HashSet<Group>();
        }

        /// <summary>
        /// Contains the list of players and the goban.
        /// </summary>
        public GameContext GameContext
        {
            get { return _gameContext; }
        }

        /// <summary>
        /// The free positions on the goban at this turn.
        /// </summary>
        public IEnumerable<Position> FreePositions
        {
            get { return _gameContext.Goban.Positions.Where(x => IsPositionFree(x)); }
        }

        private bool IsPositionFree(Position position)
        {
            foreach (var group in _groups)
            {
                if (group.Contains(position))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The groups present on the goban at this turn.
        /// </summary>
        public IEnumerable<Group> Groups
        {
            get { return _groups.ToArray(); }
        }


        public IEnumerable<Position> GetFreedoms(Group group)
        {
            if (!_groups.Contains(group))
            {
                throw new ArgumentException("Group must be a group present on the goban at this turn.");
            }
            return group.AdjacentPositions.Intersect(FreePositions);
        }

        /// <summary>
        /// The player who must play at this turn.
        /// </summary>
        public Player CurrentPlayer
        {
            get { return _gameContext.Players[_playerTurn]; }
        }

    }
}
