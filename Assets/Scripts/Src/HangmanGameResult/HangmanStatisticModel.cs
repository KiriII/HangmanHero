using System.Collections.Generic;

namespace Src.HangmanGameResult
{
    public class HangmanStatisticModel : IGamesStatisticModel
    {
        private List<HangmanGameFinishedState> _hangmanGamesStatistic;

        public HangmanStatisticModel()
        {
            _hangmanGamesStatistic = new List<HangmanGameFinishedState>();
        }

        public HangmanStatisticModel(List<HangmanGameFinishedState> hangmanGamesStatistic)
        {
            _hangmanGamesStatistic = hangmanGamesStatistic;
        }
        
        public void AddGameToStatisticWithState(HangmanGameFinishedState gameFinishedState)
        {
            _hangmanGamesStatistic.Add(gameFinishedState);
        }

        public List<HangmanGameFinishedState> GetGamesStatistic()
        {
            return _hangmanGamesStatistic;
        }
        
        public int GetGamesCountWithState(HangmanGameFinishedState gameFinishedState)
        {
            var gamesWithState = _hangmanGamesStatistic.FindAll(state => state == gameFinishedState);
            var countThisTypeOfGames = gamesWithState.Count;
            return countThisTypeOfGames;
        }
    }
}