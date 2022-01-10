using System.Collections.Generic;
using System.Linq;

namespace Src.HangmanGameStatistic
{
    public class HangmanStatisticModel
    {
        private readonly List<HangmanGameFinishedState> _hangmanGamesStatistic;

        public HangmanStatisticModel()
        {
            _hangmanGamesStatistic = new List<HangmanGameFinishedState>();
        }

        public HangmanStatisticModel(List<HangmanGameFinishedState> hangmanGamesStatistic)
        {
            _hangmanGamesStatistic = new List<HangmanGameFinishedState>(hangmanGamesStatistic);
        }
        
        public void AddGameToStatisticWithState(HangmanGameFinishedState gameFinishedState)
        {
            _hangmanGamesStatistic.Add(gameFinishedState);
        }

        public IReadOnlyList<HangmanGameFinishedState> GetGamesStatistic()
        {
            return _hangmanGamesStatistic;
        }
        
        public int GetGamesCountWithState(HangmanGameFinishedState gameFinishedState)
        {
            var countThisTypeOfGames = _hangmanGamesStatistic.Count(state => state == gameFinishedState);
            return countThisTypeOfGames;
        }
    }
}