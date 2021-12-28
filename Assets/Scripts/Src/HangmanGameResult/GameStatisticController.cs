using Src.HangmanCoreGameplay;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class GameStatisticController
    {
        private IGamesStatisticModel _gamesStatisticModel;
        private IHangmanGameCoreData _hangmanGameCoreData;

        public GameStatisticController(IGamesStatisticModel gamesStatisticModel,
            IHangmanGameCoreData hangmanGameCoreData)
        {
            _gamesStatisticModel = gamesStatisticModel;
            _hangmanGameCoreData = hangmanGameCoreData;
        }

        public void CalculateGameResultAfterWordOpened()
        {
            if (IsGameWined())
            {
                UpdateStatistic(HangmanGameFinishedState.Victory);
            } 
        }
        
        private bool IsGameWined()
        {
            var isAllWordOpened = _hangmanGameCoreData.IsHiddenWordOpened();
            return isAllWordOpened;
        }

        public void CalculateGameResultAfterErrorDone()
        {
            if (IsGameFailed())
            {
                UpdateStatistic(HangmanGameFinishedState.Failed);
            } 
        }

        private bool IsGameFailed()
        {
            var errorsRunOut = _hangmanGameCoreData.IsErrorsRunOut();
            return errorsRunOut;
        }

        private void UpdateStatistic(HangmanGameFinishedState hangmanGameFinishedState)
        {
            _gamesStatisticModel.AddGameToStatisticWithState(hangmanGameFinishedState);
        }
    }
}