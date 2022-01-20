using System.Collections.Generic;
using System.Linq;

namespace Src.HangmanGameStatistic
{
    public class HangmanStatisticModel
    {
        private readonly List<HangmanGameState> _hangmanGamesStatistic;

        public HangmanStatisticModel()
        {
            _hangmanGamesStatistic = new List<HangmanGameState>();
        }

        public HangmanStatisticModel(List<HangmanGameState> hangmanGamesStatistic)
        {
            _hangmanGamesStatistic = new List<HangmanGameState>(hangmanGamesStatistic);
        }
        
        public void AddGameToStatisticWithState(HangmanGameState gameFinishedState)
        {
            _hangmanGamesStatistic.Add(gameFinishedState);
        }

        public IReadOnlyList<HangmanGameState> GetGamesStatistic()
        {
            return _hangmanGamesStatistic;
        }
        
        public int GetGamesCountWithState(HangmanGameState gameFinishedState)
        {
            var countThisTypeOfGames = _hangmanGamesStatistic.Count(state => state == gameFinishedState);
            return countThisTypeOfGames;
        }
    }
}