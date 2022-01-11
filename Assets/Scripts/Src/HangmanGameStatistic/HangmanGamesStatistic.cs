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

        public void UpdateStatistic(HangmanGameFinishedState hangmanGameFinishedState)
        {
            _gamesStatisticModel.AddGameToStatisticWithState(hangmanGameFinishedState);
        }
        
        public int GetWinsCount()
        {
            return _gamesStatisticModel.GetGamesCountWithState(HangmanGameFinishedState.Victory);
        }

        public int GetLosesCount()
        {
            return _gamesStatisticModel.GetGamesCountWithState(HangmanGameFinishedState.Failed);
        }
    }
}