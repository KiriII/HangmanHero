using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public class HangmanGameResult : IHangamGameResult
    {
        private GameResultModel _gameResultModel;
        private GameResultController _gameResultController;
        private GameResultCalculator _gameResultCalculator;

        public HangmanGameResult(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameResultCalculator = new GameResultCalculator(hangmanGameCoreData);
            _gameResultController = new GameResultController(_gameResultCalculator);

            StartNewGame(hangmanGameCoreData);
        }
        
        public void StartNewGame(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameResultCalculator.SetHangmanGameCoreData(hangmanGameCoreData);
            AddActionsListeners(hangmanGameCoreData);
        }
        
        private void AddActionsListeners(IHangmanGameCoreData hangmanGameCoreData)
        {
            hangmanGameCoreData.EnableOpenedSymbolsGroupChangedListener(_gameResultController.CalculateGameResultAfterWordOpened);
            hangmanGameCoreData.EnableErrorsCountChangedListener(_gameResultController.CalculateGameResultAfterErrorDone);
        }

        public void EnableGameStateChangedListener(Action<HangmanGameFinishedState> methodInListener)
        {
            _gameResultController.EnableGameStateChangedListener(methodInListener);
        }
        
        public void DisableGameStateChangedListener(Action<HangmanGameFinishedState> methodInListener)
        {
            _gameResultController.DisableGameStateChangedListener(methodInListener);
        }
    }
}