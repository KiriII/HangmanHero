using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public class HangmanGameResult : IHangamGameResult
    {
        private GameResultModel _gameResultModel;
        private GameResultController _gameStatisticController;

        public HangmanGameResult(IHangmanGameCoreData hangmanGameCoreData)
        {
            StartNewGame(hangmanGameCoreData);
        }
        
        public void StartNewGame(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameStatisticController.SetHangmanGameCoreData(hangmanGameCoreData);
            AddActionsListeners(hangmanGameCoreData);
        }
        
        private void AddActionsListeners(IHangmanGameCoreData hangmanGameCoreData)
        {
            hangmanGameCoreData.EnableOpenedSymbolsGroupChangedListener(_gameStatisticController.CalculateGameResultAfterWordOpened);
            hangmanGameCoreData.EnableErrorsCountChangedListener(_gameStatisticController.CalculateGameResultAfterErrorDone);
        }

        public void EnableGameStateChangedListener(Action<HangmanGameFinishedState> methodInListener)
        {
            _gameStatisticController.EnableGameStateChangedListener(methodInListener);
        }
        
        public void DisableGameStateChangedListener(Action<HangmanGameFinishedState> methodInListener)
        {
            _gameStatisticController.DisableGameStateChangedListener(methodInListener);
        }
    }
}