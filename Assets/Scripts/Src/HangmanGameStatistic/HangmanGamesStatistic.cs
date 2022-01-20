using Src.HangmanGameResult;
using UnityEngine;

namespace Src.HangmanGameStatistic
{
    public class HangmanGamesStatistic : IHangmanGamesStatistic
    {
        private HangmanStatisticModel _gamesStatisticModel;

        public HangmanGamesStatistic()
        {
            _gamesStatisticModel = new HangmanStatisticModel();
        }

        public void UpdateStatistic(HangmanGameState hangmanGameFinishedState)
        {
            _gamesStatisticModel.AddGameToStatisticWithState(hangmanGameFinishedState);
        }
        
        public int GetWinsCount()
        {
            return _gamesStatisticModel.GetGamesCountWithState(HangmanGameState.GameWon);
        }

        public int GetLosesCount()
        {
            return _gamesStatisticModel.GetGamesCountWithState(HangmanGameState.GameLost);
        }
    }
}