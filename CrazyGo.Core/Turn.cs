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
        /// Previous <see cref="Turn"/>.
        /// </summary>
        public Turn Previous { get; private set; }

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
            Previous = null;
        }

        private Turn initializeNextTurn()
        {
            Turn nextTurn = new Turn(_gameContext);
            nextTurn._playerTurn = (_playerTurn + 1) % _gameContext.Players.Length;
            nextTurn.Previous = this;
            nextTurn._groups = new HashSet<Group>(Groups);
            return nextTurn;
        }

        /// <summary>
        /// Returns true if the given <paramref name="stone"/> is going to capture a <see cref="Group"/>.
        /// </summary>
        /// <param name="stone"></param>
        /// <returns></returns>
        public bool IsCapturing(Stone stone)
        {
            foreach (var group in _groups.Where(g => g.Player != stone.Player))
            {
                var freedoms = GetFreedoms(group);
                if (freedoms.Contains(stone.Position) && freedoms.Count() == 1)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Instantiates the next <see cref="Turn"/> by playing an <paramref name="action"/>.
        /// The returned new <see cref="Turn"/> is null if the <paramref name="action"/> breaks the rules.
        /// </summary>
        /// <param name="action"></param>
        /// <returns>The next <see cref="Turn"/> can be null if <paramref name="action"/> breaks the rules.</returns>
        public Turn NextTurn(Action action)
        {
            if (action == null)
            {
                return null;
            }

            if (action.Player != CurrentPlayer)
            {
                return null;
            }
            
            if (action is PassHand)
            {
                return initializeNextTurn();
            }

            else if (action is PlaceStone)
            {
                var placeStone = action as PlaceStone;
                var stone = placeStone.Stone;
                if (!FreePositions.Contains(stone.Position))
                {
                    return null;
                }

                Turn nextTurn = initializeNextTurn();

                // Remove captured groups
                for (int g = 0; g < nextTurn._groups.Count; g++)
                {
                    var group = nextTurn._groups.ElementAt(g);
                    if (group.Player != stone.Player)
                    {
                        var f = GetFreedoms(group);
                        if (f.Count() == 1 && f.Contains(stone.Position))
                        {
                            nextTurn._groups.Remove(group);
                            g--;
                        }
                    }                    
                }

                // Create a new group with the new stone
                Group newGroup = new Group(stone);

                // Merge adjacent groups
                for (int g = 0; g < nextTurn._groups.Count; g++)
                {
                    var group = nextTurn._groups.ElementAt(g);
                    if (group.Player == stone.Player && group.AdjacentPositions.Contains(stone.Position))
                    {
                        newGroup += group;
                        nextTurn._groups.Remove(group);
                        g--;
                    }
                }

                nextTurn._groups.Add(newGroup);

                // Check that newGroup hast freedom in nextTurn
                if (!nextTurn.GetFreedoms(newGroup).Any())
                {
                    return null;
                }

                // Check Ko rule
                if (nextTurn.isSameState(Previous))
                {
                    return null;
                }

                // Action is valid, nextTurn is well created
                return nextTurn;

            }
            else
            {
                throw new ArgumentException("Action expected to be PlaceStone or PassHand.");
            }
        }


        private bool isSameState(Turn other)
        {
            return other != null &&
                   ReferenceEquals(_gameContext, other._gameContext) &&
                   _playerTurn == other._playerTurn &&
                   _groups.SetEquals(other._groups);
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
            Previous = null;
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


        /// <summary>
        /// Returns a collection of free <see cref="Position"/>.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
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

        public Player NextPlayer
        {
            get
            {
                int n = _gameContext.Players.Length;
                return _gameContext.Players[(_playerTurn + 1) % n];
            }
        }

    }
}
