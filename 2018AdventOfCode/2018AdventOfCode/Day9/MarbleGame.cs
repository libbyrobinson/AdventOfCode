using System.Collections.Generic;
using System.Linq;

namespace _2018AdventOfCode.Day9
{
    public class MarbleGame
    {
        private readonly Dictionary<int, long> _playerScores;
        private int _currentPlayerIndex;
        private Marble _currentMarble;

        public MarbleGame(int numPlayers)
        {
            _playerScores = new Dictionary<int, long>();
            for (var player = 0; player < numPlayers; player++)
            {
                _playerScores.Add(player, 0);
            }
            _currentPlayerIndex = -1;

            CurrentMarbleValue = 0;
            _currentMarble = new Marble
            {
                Value = CurrentMarbleValue
            };
            _currentMarble.Next = _currentMarble;
            _currentMarble.Previous = _currentMarble;
        }

        public void PlaceNextMarble()
        {
            CurrentMarbleValue++;
            var nextMarble = new Marble
            {
                Value = CurrentMarbleValue
            };

            _currentPlayerIndex++;
            if (_currentPlayerIndex == _playerScores.Count)
            {
                _currentPlayerIndex = 0;
            }

            if (nextMarble.Value % 23 == 0)
            {
                var marbleToRemove = _currentMarble.Previous.Previous.Previous.Previous.Previous.Previous.Previous;

                _playerScores[_currentPlayerIndex] += nextMarble.Value;
                _playerScores[_currentPlayerIndex] += marbleToRemove.Value;

                marbleToRemove.Previous.Next = marbleToRemove.Next;
                marbleToRemove.Next.Previous = marbleToRemove.Previous;

                _currentMarble = marbleToRemove.Next;
            }
            else
            {
                var leftMarble = _currentMarble.Next;
                var rightMarble = _currentMarble.Next.Next;

                nextMarble.Previous = leftMarble;
                nextMarble.Next = rightMarble;

                leftMarble.Next = nextMarble;
                rightMarble.Previous = nextMarble;

                _currentMarble = nextMarble;
            }
        }

        public long CurrentMarbleValue { get; private set; }
        public long HighScore => _playerScores.Values.Max();
    }
}