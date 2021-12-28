using System;
using Src.HangmanCoreGameplay;

namespace Src.HangmanGameResult
{
    public class HangmanGameResult : IHangamGameResult
    {
        private GameStatisticController _gameStatisticController;

        public HangmanGameResult(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameStatisticController = new GameStatisticController(hangmanGameCoreData);

            AddActionsListeners(hangmanGameCoreData);
        }
        private void AddActionsListeners(IHangmanGameCoreData hangmanGameCoreData)
        {
            hangmanGameCoreData.SetOpenedSymbolsGroupChanged(_gameStatisticController.CalculateGameResultAfterWordOpened);
            hangmanGameCoreData.SetErrorsCountChanged(_gameStatisticController.CalculateGameResultAfterErrorDone);
        }

        public void StartNewGame(IHangmanGameCoreData hangmanGameCoreData)
        {
            _gameStatisticController.SetHangmanGameCoreData(hangmanGameCoreData);
            AddActionsListeners(hangmanGameCoreData);
        }

        public void SetGameStateChanged(Action<HangmanGameFinishedState> methodInListener)
        {
            _gameStatisticController.SetGameStateChanged(methodInListener);
        }
    }
}