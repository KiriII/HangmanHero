using Src.HangmanCoreGameplay;
using UnityEngine;

namespace Src.HangmanGameResult
{
    public class GameStatisticController
    {
        //TODO REMOVE
        private const int MAX_ERRORS_COUNT = 6;
        
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
            Debug.Log("TRY CHECK GAME WON");
            if (IsGameWined())
            {
                Debug.Log("GAME WON");
                UpdateStatistic(HangmanGameState.Victory);
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
                UpdateStatistic(HangmanGameState.Failed);
            } 
        }

        private bool IsGameFailed()
        {
            var errorsDoneInCurrentGame = _hangmanGameCoreData.GetErrorsCount();
            return errorsDoneInCurrentGame == MAX_ERRORS_COUNT;
        }

        private void UpdateStatistic(HangmanGameState hangmanGameState)
        {
            _gamesStatisticModel.FinishLastInGroupGame(hangmanGameState);
        }
    }
}