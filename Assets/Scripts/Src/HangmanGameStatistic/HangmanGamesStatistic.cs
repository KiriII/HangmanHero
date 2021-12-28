using Src.HangmanGameResult;
using UnityEngine;

namespace Src.HangmanGameStatistic
{
    public class HangmanGamesStatistic : IHangmanGamesStatistic
    {
        private IGamesStatisticModel _gamesStatisticModel;

        public HangmanGamesStatistic(IHangamGameResult hangamGameResult)
        {
            _gamesStatisticModel = new HangmanStatisticModel();
            hangamGameResult.SetGameStateChanged(UpdateStatistic);
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