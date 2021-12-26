using System.Collections.Generic;

namespace Src.HangmanGameResult
{
    public class HangmanStatisticModel : IGamesStatisticModel
    {
        private List<HangmanGameState> _hangmanGamesStatistic;

        public HangmanStatisticModel()
        {
            _hangmanGamesStatistic = new List<HangmanGameState>();
        }

        public HangmanStatisticModel(List<HangmanGameState> hangmanGamesStatistic)
        {
            _hangmanGamesStatistic = hangmanGamesStatistic;
        }
        
        public void AddGameToStatisticWithState(HangmanGameState gameState)
        {
            _hangmanGamesStatistic.Add(gameState);
        }

        public void FinishLastInGroupGame(HangmanGameState gameState)
        {
            var countOfGames = _hangmanGamesStatistic.Count;
            _hangmanGamesStatistic[countOfGames] = gameState;
        }

        public List<HangmanGameState> GetGamesStatistic()
        {
            return _hangmanGamesStatistic;
        }
        
        public int GetGamesCountWithState(HangmanGameState gameState)
        {
            var gamesWithState = _hangmanGamesStatistic.FindAll(state => state == gameState);
            var countThisTypeOfGames = gamesWithState.Count;
            return countThisTypeOfGames;
        }
    }
}